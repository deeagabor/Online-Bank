const getAccountsTable = document.getElementById('accounts-table');
const portUrl = 'https://localhost:57658';
const usersUrl = '/api/users/';
const accountsUrl = '/accounts';

const id = sessionStorage.getItem("id");

if(!id)
{
    window.location = 'login.html';
}

const url = portUrl + usersUrl + `${id}` + accountsUrl;


// GET ACCOUNTS

fetch(url)
.then(res => res.json())
.then(data => getAccount(data))


function seeDeposits(accountId)
{
    sessionStorage.setItem("accountId",accountId);

    window.location = 'deposits-user.html';
}


const noData = document.getElementById("no-data");

function getAccount(accounts){
    accounts.forEach(account => {
        let row = `<tr>
            <td id="firstname">${account.firstName}</td>
            <td id="lastname">${account.lastName}</td>
            <td id="sum">${account.sum}</td>
            <td>
                <button id="deposits" class="button-deposits" onclick="seeDeposits(${account.id})"> <i class="fa fa-list"></i></button>
            </td>
        </tr>`;

        if(getAccountsTable != null)
        {
            const getAccountsTable = document.getElementById('accounts-table');
            const newRow = document.createElement('tr');
            newRow.innerHTML = row;
            getAccountsTable.appendChild(newRow);
        }
    });

    if(accounts.length == 0 || getAccountsTable.innerHTML === "")
    {
        noData.innerText = "There are no accounts!";
    }
}




// BUTTONS

function logoutButton(){
    sessionStorage.clear();
    window.location = 'login.html';
}
