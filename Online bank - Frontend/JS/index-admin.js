const getAccountsTable = document.getElementById('accounts-table');

const portUrl = 'https://localhost:57658';
const accountsUrl = '/api/accounts';
const url = portUrl + accountsUrl;

const id = sessionStorage.getItem("id");

if(!id)
{
    window.location = 'login.html';
}

// GET ACCOUNTS


fetch(url)
.then(res => res.json())
.then(data => getAccount(data))


const noData = document.getElementById("no-data");

function getAccount(accounts){
    accounts.forEach(account => {
        let row = `<tr>
                    <td id="firstname">${account.firstName}</td>
                    <td id="lastname">${account.lastName}</td>
                    <td id="sum">${account.sum}</td>
                    <td>
                        <button id="deposits" class="button-deposits" onclick="seeDeposits(${account.id})"> <i class="fa fa-list"></i></button>
                        <button id="edit-account" class="button-edit" onclick="editAccount(${account.id},'${account.firstName}','${account.lastName}',${account.userId},${account.sum})"><i class="fa fa-pencil"></i></button>
                        <button id="delete-account" class="button-delete" onclick="deleteAccount(${account.id})"> <i class="fa fa-trash"></i></button>
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

function seeDeposits(accountId)
{
    sessionStorage.setItem("accountId",accountId);
    window.location = 'deposits-admin.html';
}

function editAccount(accountId,firstName,lastName,userId,accountSum)
{
    sessionStorage.setItem("accountId",accountId);
    sessionStorage.setItem("firstName",firstName);
    sessionStorage.setItem("lastName",lastName);
    sessionStorage.setItem("userId",userId);
    sessionStorage.setItem("accountSum",accountSum);

    window.location = 'edit-account.html';
}

function deleteAccount(accountId)
{
    const deleteUrl = url + '/' +`${accountId}`;

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


// BUTTONS

function addButton() {
    sessionStorage.setItem("id",id);
    document.location.href = "add-account.html";
}

function logoutButton(){
    sessionStorage.clear();
    window.location = 'login.html';
}
