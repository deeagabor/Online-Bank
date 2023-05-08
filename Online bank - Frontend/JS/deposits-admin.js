const getDepositsTable = document.getElementById('deposits-table');
const portUrl = 'https://localhost:57658';
const accountsUrl = '/api/accounts';
const depositsUrl = '/deposits';



const id = sessionStorage.getItem("accountId");

if(!id)
{
    window.location = 'login.html';
}

const getDepositsUrl = portUrl + accountsUrl + '/' +`${id}` + depositsUrl;


function editDeposit(depositId,depositName,depositPeriod,depositSum)
{
    sessionStorage.setItem("id",id);
    sessionStorage.setItem("depositId",depositId);
    sessionStorage.setItem("depositName",depositName);
    sessionStorage.setItem("depositPeriod",depositPeriod);
    sessionStorage.setItem("depositSum",depositSum);
    
    window.location = 'edit-deposit.html';
}

function deleteDeposit(depositId)
{
    const deleteUrl = getDepositsUrl + '/' + `${depositId}`;

    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this data!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
    .then((willDelete) => {
        if(willDelete) 
        {
            fetch(deleteUrl, {
                method: 'DELETE',
            })
            .then(res =>{
                if(!res.ok){
                    throw new Error("Delete failed");
                }
            })
            .then(() => location.reload())
            .catch(error => console.error(error))
        }
    })
}



//GET AND FILTER-GET

const option1Months = document.getElementById("option-1-months");
const option6Months = document.getElementById("option-6-months");
const option12Months = document.getElementById("option-12-months");

const saveButton = document.getElementById("button-save");

const refresh = document.getElementById("refresh");



refresh.addEventListener('click', (e) => {
    e.preventDefault();
    noData.innerText = "";
    getDepositsTable.innerText = '';

    fetch(getDepositsUrl)
    .then(res => res.json())
    .then(data => getDeposit(data))
    
})



saveButton.addEventListener('click', (e) => {
    e.preventDefault();
    let period;

    if(option1Months.checked)
    {
        period = 1;
    }

    if(option6Months.checked)
    {
        period = 6;
    }

    if(option12Months.checked)
    {
        period = 12;
    }

    getDepositsTable.innerHTML ="";
    getFilterData(period);
});



function getFilterData(period) {

    noData.innerText = "";

    let filterUrl = getDepositsUrl + "?period=" + `${period}`;

      fetch(filterUrl)
        .then(response => {
          if (!response.ok) {
            throw new Error("Filter failed!");
          }
          return response.json();
        })
        .then(data => getDeposit(data))
        .catch(error => console.error(error))
}


fetch(getDepositsUrl)
.then(res => res.json())
.then(data => getDeposit(data))



const noData = document.getElementById("no-data");

function getDeposit(deposits){
    deposits.forEach(deposit => {
        let row = `<tr>
                    <td id="name">${deposit.name}</td>
                    <td id="period">${deposit.period}</td>
                    <td id="sum">${deposit.depositSum}</td>
                    <td>
                        <button id="edit-deposit" class="button-edit" onclick="editDeposit(${deposit.id},'${deposit.name}',${deposit.period},${deposit.depositSum})"><i class="fa fa-pencil"></i></button>
                        <button id="delete-deposit" class="button-delete" onclick="deleteDeposit(${deposit.id})"> <i class="fa fa-trash"></i></button>
                    </td>
                </tr>`;

        if(getDepositsTable != null)
        {
            const getDepositsTable = document.getElementById('deposits-table');
            const newRow = document.createElement('tr');
            newRow.innerHTML = row;
            getDepositsTable.appendChild(newRow);
        }
    });

    if(deposits.length == 0 || getDepositsTable.innerHTML === "")
    {
        noData.innerText = "There are no deposits!";
    }
}



// BUTTONS

function addButton() {
    sessionStorage.setItem("id",id);
    window.location = 'add-deposit.html';
}

function logoutButton(){
    sessionStorage.clear();
    window.location = 'login.html';
}

