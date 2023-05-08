const getAccountsTable = document.getElementById('accounts-table');
const getUsernames = document.getElementById('username-input');


const portUrl = 'https://localhost:57658';
const accountsUrl = '/api/accounts';
const usersUrl = '/api/users'
const url = portUrl + accountsUrl;

const id = sessionStorage.getItem("id");

if(!id)
{
    window.location = 'login.html';
}


const addAccountsForm = document.getElementById('form');
const username = document.getElementById('username-input');
const firstName = document.getElementById('firstname-input');
const lastName = document.getElementById('lastname-input');
const sum = document.getElementById('sum-input');

const error = document.getElementById('error');


fetch(portUrl + usersUrl)
.then(res => res.json())
.then(data => getUser(data))


addAccountsForm.addEventListener('submit', (e) => {
    e.preventDefault();

    let messages = [];

    validateInputs(messages);

    if(messages.length > 0)
    {
        error.innerText = messages.join('\n');
    }
    
    if(messages.length == 0)
    {

        const usernamesUrl = '/usernames/';
        const searchUsernameUrl = portUrl + usersUrl + usernamesUrl + `${username.value}`;

        fetch(searchUsernameUrl)
        .then(res => res.json())
        .then(data => {
            postAccount(data.id);
        })
    }
});



function postAccount(userId){
    fetch(url, {
        method: "POST",
        headers: {
            'content-type': 'application/json; charset=UTF-8',
        },
        body:JSON.stringify({
            firstName: firstName.value,
            lastName: lastName.value,
            sum: sum.value,
            userId: userId 
         })
    })
    .then(res => {
        if(!res.ok){
            throw new Error("Post failed");
        }

        swal("The account has been successfully created!")
        .then(() => {
            addAccountsForm.reset();
            error.innerText = ""; 
            window.location = 'index-admin.html';
        });
    })
    .then(data => {
        const dataArray = [];
        dataArray.push(data);
        getAccount(dataArray);
    })
    .catch(error => console.error(error))
}



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
}

function getUser(users){

    getUsernames.innerHTML = `<option selected disabled>Choose username</option>`;

    users.forEach(user => {
        let row = `<option value="${user.username}">${user.username}</option>`

        if(getUsernames != null && user.admin !== true)
        {
            const getUsernames = document.getElementById('username-input');
            const newRow = document.createElement('option');
            newRow.innerHTML = row;
            getUsernames.appendChild(newRow);
        }
    });
}


function validateInputs(messages){

    const disableOption = getUsernames.options[0];
    
    if(getUsernames.value === disableOption.value)
    {
        messages.push("Username is required!");
    }

    if(firstName.value === '' || firstName.value === null)
    {
        messages.push("Owner's first name is required!");
    }

    if(firstName.value.length > 50)
    {
        messages.push("Owner's first name can have a maximum of 50 characters!");
    }

    if(lastName.value === '' || lastName.value === null)
    {
        messages.push("Owner's last name is required!");
    }

    if(lastName.value.length > 50)
    {
        messages.push("Owner's last name can have a maximum of 50 characters!");
    }

    if(sum.value < 0)
    {
        messages.push("Account's amount must be a positive number!");
    }
}
