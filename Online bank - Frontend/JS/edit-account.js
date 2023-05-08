const portUrl = 'https://localhost:57658';
const accountsUrl = '/api/accounts';
const usersUrl = '/api/users'


const id = sessionStorage.getItem("accountId");
const firstName = sessionStorage.getItem("firstName");
const lastName = sessionStorage.getItem("lastName");
const idOwner = sessionStorage.getItem("userId");
const sum = sessionStorage.getItem("accountSum");


if(!id)
{
    window.location = 'login.html';
}

const getUsernames = document.getElementById('username-input');
const username = document.getElementById('username-input');
const firstNameValue = document.getElementById('firstname-input');
const lastNameValue = document.getElementById('lastname-input');
const sumValue = document.getElementById('sum-input');

const buttonSave = document.getElementById('button');

const url = portUrl + usersUrl + '/' + `${idOwner}`;


fetch(portUrl + usersUrl)
.then(res => res.json())
.then(data => getUser(data))



fetch(url)
.then(res => res.json())
.then(data => {
    username.value = data.username;
})

firstNameValue.value = firstName;
lastNameValue.value = lastName;
sumValue.value = sum;


function getUser(users){

    users.forEach(user => {

        let row = `<option value="${user.username}">${user.username}</option>`;

        if(getUsernames != null && user.admin !== true)
        {
            const getUsernames = document.getElementById('username-input');
            const newRow = document.createElement('option');
            newRow.innerHTML = row;
            getUsernames.appendChild(newRow);
        }
    });
}

buttonSave.addEventListener('click', (e) => {
    e.preventDefault();

    let messages = [];

    validateInputs(messages);

    if(messages.length > 0)
    {
        error.innerText = messages.join('\n');
    }

    if(messages.length === 0)
    {
        const usernamesUrl = '/usernames/';
        const searchUsernameUrl = portUrl + usersUrl + usernamesUrl + `${username.value}`;

        fetch(searchUsernameUrl)
        .then(res => res.json())
        .then(data => {
            editAccount(data.id,firstNameValue,lastNameValue,sumValue);
        })
    }
})

function editAccount(userId,firstName,lastName,sumAccount)
{
    const editAccountsUrl = portUrl + accountsUrl + '/' +`${id}`;

    swal({
        title: "Are you sure?",
        text: "Once edited, you will not be able to recover this data!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
    .then((willEdit) => {
        if(willEdit) 
        {   
            fetch(editAccountsUrl, {
                method: 'PUT',
                headers: {
                    'content-type': 'application/json; charset=UTF-8',
                },
                body:JSON.stringify({
                    firstName: firstName.value,
                    lastName: lastName.value,
                    userId: userId,
                    sum: sumAccount.value
                })
            })
            .then(res => {
                if(res.status === 204)
                {
                    error.innerText = ""; 
                    window.location = 'index-admin.html';
                }
                else
                {
                    throw new Error("Put failed");
                }
            })
            .catch(error => console.error(error))
        }
    })
}

function validateInputs(messages){

    if(firstNameValue.value === '' || firstNameValue.value === null)
    {
        messages.push("Owner's first name is required!");
    }

    if(firstNameValue.value.length > 50)
    {
        messages.push("Owner's first name can have a maximum of 50 characters!");
    }

    if(lastNameValue.value === '' || lastNameValue.value === null)
    {
        messages.push("Owner's last name is required!");
    }

    if(lastNameValue.value.length > 50)
    {
        messages.push("Owner's last name can have a maximum of 50 characters!");
    }

    if(sumValue.value < 0)
    {
        messages.push("Account's amount must be a positive number!");
    }
}



 