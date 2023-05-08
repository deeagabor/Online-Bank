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

// GET DEPOSITS


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

function logoutButton(){
    sessionStorage.clear();
    window.location = 'login.html';
}
