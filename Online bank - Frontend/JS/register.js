const registerForm = document.getElementById('register');
const firstname = document.getElementById('firstname-input');
const lastname = document.getElementById('lastname-input');
const email = document.getElementById('email-input');
const username = document.getElementById('username-input');
const password = document.getElementById('password-input');
const confirmPassword = document.getElementById('confirm-password-input');

const error = document.getElementById('error');

const portUrl = 'https://localhost:57658';
const accountsUrl = '/api/users';
const url = portUrl + accountsUrl;



registerForm.addEventListener('submit', (e) => {
    e.preventDefault();

    let messages = [];

    validateInputs(messages);

    if(messages.length > 0)
    {
        error.innerText = messages.join('\n');
    }

    if(messages.length == 0)
    {
        const hashPassword = CryptoJS.SHA256(password.value).toString(CryptoJS.enc.Hex);

        swal({
            title: "Are you sure you want to complete the registration?",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
        .then((willCreate) => {
            if(willCreate) 
            {   
                fetch(url, {
                    method: "POST",
                    headers: {
                        'content-type': 'application/json; charset=UTF-8',
                    },
                    body:JSON.stringify({
                        firstName: firstname.value,
                        lastName: lastname.value,
                        email: email.value,
                        username: username.value,
                        password: hashPassword,
                        admin: false
                    })
                })
                .then(res => {
                    if(!res.ok){
                        throw new Error("Post failed");
                    }

                    registerForm.reset();
                    error.innerText = ""; 
                    window.location = 'login.html';
                })
                .catch(error => console.error(error))
            }
        })
    }
})


function validateInputs(messages){

    if(firstname.value === '' || firstname.value === null)
    {
        messages.push("First Name is required!");
    }

    if(firstname.value.length > 50)
    {
        messages.push("First Name can have a maximum of 50 characters!");
    }

    if(lastname.value === '' || lastname.value === null)
    {
        messages.push("Last Name is required!");
    }

    if(lastname.value.length > 50)
    {
        messages.push("Last Name can have a maximum of 50 characters!");
    }

    if(email.value === '' || email.value === null)
    {
        messages.push("Email is required!");
    }

    const regexEmail = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if(!regexEmail.test(email.value))
    {
        messages.push("Email is not valid!");
    }
    
    if(username.value === '' || username.value === null)
    {
        messages.push("Username is required!");
    }

    if(username.value.length > 50)
    {
        messages.push("Username can have a maximum of 50 characters!");
    }

    if(password.value === '' || password.value === null)
    {
        messages.push("Password is required!");
    }

    if(password.value.length > 50)
    {
        messages.push("Password can have a maximum of 50 characters!");
    }

    if(password.value.length < 8)
    {
        messages.push("The password must have at least 8 characters!");
    }

    if(password.value !== confirmPassword.value)
    {
        messages.push("Confirm password not match!");
    }
}


// BUTTONS

function loginButton() {
    document.location.href = "login.html";
}
