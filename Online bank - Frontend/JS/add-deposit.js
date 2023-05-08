const getDepositsTable = document.getElementById('deposits-table');
const portUrl = 'https://localhost:57658';
const accountsUrl = '/api/accounts';
const depositsUrl = '/deposits';


const id = sessionStorage.getItem("id");

if(!id)
{
    window.location = 'login.html';
}

const addDepositsUrl = portUrl + accountsUrl + '/' + `${id}` + depositsUrl;


const addDepositsForm = document.getElementById('form');
const nameDep = document.getElementById('name-input');
const period = document.getElementById('period-input');
const sum = document.getElementById('sum-input');

const error = document.getElementById('error');




addDepositsForm.addEventListener('submit', (e) => {
    e.preventDefault();

    let messages = [];

    validateInputs(messages);

    if(messages.length > 0)
    {
        error.innerText = messages.join('\n');
    }
    
    if(messages.length == 0)
    {
        fetch(addDepositsUrl, {
            method: "POST",
            headers: {
                'content-type': 'application/json; charset=UTF-8',
            },
            body:JSON.stringify({
                name: nameDep.value,
                period: period.value,
                depositSum: sum.value
            })
        })
        .then(res => {
            if(!res.ok){
                throw new Error("Post failed");
            }

            swal("The deposit has been successfully created!")
            .then(() => {
                addDepositsForm.reset();
                error.innerText = "";  
                window.location = 'deposits-admin.html';
            });
        })
        .then(data => {
            const dataArray = [];
            dataArray.push(data);
            getDeposit(dataArray);
        })
        .catch(error => console.error(error))
    }
});




function getDeposit(deposits){
    deposits.forEach(deposit => {
    let row = `<tr>
                <td id="name">${deposit.name}</td>
                <td id="period">${deposit.period}</td>
                <td id="sum">${deposit.depositSum}</td>
                <td>
                    <button id="edit-deposit" class="button-edit"><i class="fa fa-pencil"></i></button>
                    <button id="delete-deposit" class="button-delete"> <i class="fa fa-trash"></i></button>
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
}



function validateInputs(messages){

    if(nameDep.value === '' || nameDep.value === null)
    {
        messages.push("Deposit's type is required!");
    }

    if(period.value === '' || period.value === null)
    {
        messages.push("Deposit's period is required!");
    }
    else 
    {
        if(period.value !== '1' && period.value !== '6' && period.value !== '12')
        {
            messages.push("Deposit's period must be 1, 6 or 12 months!");
        }
    }

    if(nameDep.value.length > 50)
    {
        messages.push("Type's name can have a maximum of 50 characters!");
    }

    if(sum.value < 0)
    {
        messages.push("Deposit's amount must be a positive number!");
    }
}