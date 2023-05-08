const portUrl = 'https://localhost:57658';
const accountsUrl = '/api/accounts';
const depositsUrl = '/deposits';


const id = sessionStorage.getItem("id");
const depositId = sessionStorage.getItem("depositId");
const nameDep = sessionStorage.getItem("depositName");
const period = sessionStorage.getItem("depositPeriod");
const sum = sessionStorage.getItem("depositSum");


if(!depositId)
{
    window.location = 'login.html';
}

const nameValue = document.getElementById('name-input');
const periodValue = document.getElementById('period-input');
const sumValue = document.getElementById('sum-input');

const buttonSave = document.getElementById('button');

nameValue.value = nameDep;
periodValue.value = period;
sumValue.value = sum;


const editDepositsUrl = portUrl + accountsUrl + '/' +`${id}` + depositsUrl + '/' +`${depositId}`;


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
                fetch(editDepositsUrl, {
                    method: 'PUT',
                    headers: {
                        'content-type': 'application/json; charset=UTF-8',
                    },
                    body:JSON.stringify({
                        name: nameValue.value,
                        period: periodValue.value,
                        depositSum: sumValue.value
                    })
                })
                .then(res => {
                    if(res.status === 204)
                    {
                        error.innerText = ""; 
                        window.location = 'deposits-admin.html?id=' + `${id}`;
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
})


function validateInputs(messages){

    if(nameValue.value === '' || nameValue.value === null)
    {
        messages.push("Deposit's type is required!");
    }

    if(periodValue.value === '' || periodValue.value === null)
    {
        messages.push("Deposit's period is required!");
    }
    else 
    {
        if(periodValue.value !== '1' && periodValue.value !== '6' && periodValue.value !== '12')
        {
            messages.push("Deposit's period must be 1, 6 or 12 months!");
        }
    }

    if(nameValue.value.length > 50)
    {
        messages.push("Type's name can have a maximum of 50 characters!");
    }

    if(sumValue.value < 0)
    {
        messages.push("Deposit's amount must be a positive number!");
    }
}


 