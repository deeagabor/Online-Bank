const portUrl = 'https://localhost:57658';
const usersUrl = '/api/users';
const url = portUrl + usersUrl;


const loginForm = document.getElementById('login');
const username = document.getElementById('username-input');
const password = document.getElementById('password-input');


const error = document.getElementById('error');

loginForm.addEventListener('submit', (e) => {
    e.preventDefault();

    let messages = [];

    validateInputs(messages);

    if(messages.length > 0)
    {
        error.innerText = messages.join('\n');
    }

    if(messages.length === 0)
    {
        sendCredentials(username,password);
    }
})


function sendCredentials(username, password) {

    const hashPassword = CryptoJS.SHA256(password.value).toString(CryptoJS.enc.Hex);


    const loginUrl = '/api/login';
    const url = portUrl + loginUrl;

    fetch(url, {
        method: "POST",
        headers: {
            'content-type': 'application/json; charset=UTF-8',
        },
        body:JSON.stringify({
            username: username.value,
            password: hashPassword
        })
    })
    .then(res => {
        if(!res.ok){
            swal("This account doesn't exist!"); 
            throw new Error("Login failed");
        }
        error.innerText = "";
        return res.json();
    })
    .then(data => {
        if(data.admin == true)
        {
            sessionStorage.setItem("id",data.id);
            window.location = 'index-admin.html';
        }
        else
        {
            sessionStorage.setItem("id", data.id);
            window.location = 'index-user.html';
        }
    })
    .catch(error => console.error(error))
}

function validateInputs(messages){

    if(username.value === '' || username.value === null)
    {
        messages.push("Username is required!");
    }

    if(password.value === '' || password.value === null)
    {
        messages.push("Password is required!");
    }
}

// BUTTONS

function registerButton() {
    document.location.href = "register.html";
}

