 function displayTrainer(){
 
 fetch('https://localhost:7108/api/Trainer/All')
    .then(res=>{
        return res.json();
    })
    .then(data=>{
        data.forEach(element => {
            const markup=`<div class="card"><h5>Name:  ${element.name} </h5><p>Email:  ${element.email}</p>
            <p>Gender: ${element.gender}</p> <p class="card-text" >Age: ${element.age} </p><p>Phone_Number: ${element.phoneNumber}</p>
            <p>City:${element.city}</p><p> ZipCode:${element.zipcode}</p></div>`;
            document.querySelector('div').insertAdjacentHTML('beforeend',markup);
            //console.log(element.name);
            
        });
    })
}

function Login(){
    const formE1 = document.querySelector('.form');
    
    formE1.addEventListener('submit', e => {
        e.preventDefault();
                var email=document.getElementById('Email').value;
                var pass=document.getElementById('Password').value;
               localStorage.setItem("ParticularEmail",email) ;
    
        // Make a request to the API endpoint to validate the login credentials
        fetch(`https://localhost:7108/api/Trainer/Login`,{
          method:'GET',
          headers:{
            'Content-Type':'application/json',
            'email':email,
            'password':pass
          }
        })
        //body:JSON.stringify(data)
        .then(response => {
            if (response.status===200) {
                // If the login is successful, display a success message
                alert( 'Login successful!');
                window.location.replace('Layout.html');
            } else {
                // If the login is unsuccessful, display an error message
                alert('Login Failed')
            }
        })
        .catch(error =>console.log(error));
    });
    }
        
        
    
    
    


function GetPersonalDetails()
{

var email=localStorage.getItem("ParticularEmail");

            
fetch(`https://localhost:7108/api/Trainer/getTrainerDetails`,{
      method:'GET',
      headers:{
        'Content-Type':'application/json',
        'email':email
        
      }
    })
    .then(response=>{
        if(response.ok){
            return response.json();
        }
    })
    .then(data=>{
       console.log(data);
    
       const markup=`<div class="card"><h5>Name:  ${data.name} </h5><p>Email:  ${data.email}</p>
       <p>Gender: ${data.gender}</p> <p class="card-text" >Age: ${data.age} </p><p>Phone_Number: ${data.phoneNumber}</p>
       <p>City:${data.city}</p><p> ZipCode:${data.zipcode}</p></div>`;
       document.querySelector('div').insertAdjacentHTML('beforeend',markup);
    });      
    
}

function GetSkilllDetails()
{

var email=localStorage.getItem("ParticularEmail");
        
fetch('https://localhost:7108/api/Skill/All',{
  method:'GET',
  headers:{
    'Content-Type':'application/json',
    'email':email
    
  }
})
.then(response=>{
    if(response.ok){
        return response.json();
    }
})
.then(data=>{
    data.forEach(element => {
        const markup=`<div class="card"><h5> SkillName: ${element.skillName} </h5><p> Proficiency:  ${element.proficiency}</p></div>`;
        document.querySelector('div').insertAdjacentHTML('beforeend',markup);
    });
})
      

}

function GetCompanyDetails()
{

var email=localStorage.getItem("ParticularEmail");
        
fetch('https://localhost:7108/api/Company/All',{
  method:'GET',
  headers:{
    'Content-Type':'application/json',
    'email':email
    
  }
})
.then(response=>{
    if(response.ok){
        return response.json();
    }
})
.then(data=>{
    data.forEach(element => {
        const markup=`<div class="card"><h5> CompanyName: ${element.cmpName} </h5><p> Role:  ${element.role}</p>
        <p> Experience: ${element.experience}</div>`;
        document.querySelector('div').insertAdjacentHTML('beforeend',markup);
    });
})
      

}

function GetEducationDetails()
{

var email=localStorage.getItem("ParticularEmail");
        
fetch('https://localhost:7108/api/Education/All',{
  method:'GET',
  headers:{
    'Content-Type':'application/json',
    'email':email
    
  }
})
.then(response=>{
    if(response.ok){
        return response.json();
    }
})
.then(data=>{
    data.forEach(element => {
        const markup=`<div class="card"><h5> Institution:  ${element.degree}</h5> <p> Education Name: ${element.institution} </p></div>`;
        document.querySelector('div').insertAdjacentHTML('beforeend',markup);
    });
})
      

}

function GetAvailabilityDetails()
{

var email=localStorage.getItem("ParticularEmail");
        
fetch('https://localhost:7108/api/Availability/All',{
  method:'GET',
  headers:{
    'Content-Type':'application/json',
    'email':email
    
  }
})
.then(response=>{
    if(response.ok){
        return response.json();
    }
})
.then(data=>{
    data.forEach(element => {
        const markup=`<div class="card"><h5> Day:  ${element.day}</h5> <p> Start Time: ${element.startTime} </p>
        <p> End Time: ${element.endTime} </p> <p> Hourly Rate: ${element.hourlyRate}</p></div>`;
        document.querySelector('div').insertAdjacentHTML('beforeend',markup);
    });
})
      

}


function AddSkill(){
    var email=localStorage.getItem("ParticularEmail");
    const formE1=document.querySelector('.form');
    console.log(formE1);
    formE1.addEventListener('submit',event => {
        event.preventDefault();
        const formData=new FormData(formE1);
        const data = Object.fromEntries(formData);
        console.log(data);
        
        fetch('https://localhost:7108/api/Skill/Add',{
            method:'POST',
            headers:{
                'Content-Type': 'application/Json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(Response=>{
            if(Response.status===201){
                alert("Skill Added Successfully!!!!");
                window.location.replace('Layout.html');
            }
            else{
                alert("failed to add skill");
            }
        })
        
           
          .catch(error=>console.log(error));
    });
}



function AddCompany(){
    var email=localStorage.getItem("ParticularEmail");
    const formE1=document.querySelector('.form');
    console.log(formE1);
    formE1.addEventListener('submit',event => {
        event.preventDefault();
        const formData=new FormData(formE1);
        const data = Object.fromEntries(formData);
        console.log(data);
        
        fetch('https://localhost:7108/api/Company/Add',{
            method:'POST',
            headers:{
                'Content-Type': 'application/Json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(Response=>{
            if(Response.status===201){
                alert("Company Added Successfully!!!!");
                window.location.replace('Layout.html');
            }
            else{
                alert("Failed to Add Company");
            }
        })
        
           
          .catch(error=>console.log(error));
    });
}



function AddEducation(){
    var email=localStorage.getItem("ParticularEmail");
    const formE1=document.querySelector('.form');
    console.log(formE1);
    formE1.addEventListener('submit',event => {
        event.preventDefault();
        const formData=new FormData(formE1);
        const data = Object.fromEntries(formData);
        console.log(data);
        
        fetch('https://localhost:7108/api/Education/Add',{
            method:'POST',
            headers:{
                'Content-Type': 'application/Json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(Response=>{
            if(Response.status===201){
                alert("Education Added Successfully!!!!");
                window.location.replace('Layout.html');
            }
            else{
                alert("Failed to Add Education details");
            }
        })
        .catch(error=>console.log(error));
    });
}


function AddAvailability(){
    var email=localStorage.getItem("ParticularEmail");

const formE1=document.querySelector('.form');
    console.log(formE1);
    formE1.addEventListener('submit',event => {
        event.preventDefault();
        const formData=new FormData(formE1);
        const data = Object.fromEntries(formData);
        console.log(data);
        
        fetch('https://localhost:7108/api/Availability/Add',{
            method:'POST',
            headers:{
                'Content-Type': 'application/Json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(Response=>{
            if(Response.status===201){
                alert("Availability Added Successfully!!!!");
                window.location.replace('Layout.html');
            }
            else{
                alert("Failed to Add Availability details");
            }
        })
        .catch(error=>console.log(error));
    });
}


function DeleteTrainer(){
    const formE1 = document.querySelector('.form');
    console.log(formE1);
    
    formE1.addEventListener('submit', e => {
        e.preventDefault();
                var email=document.getElementById('Email').value;
                //var email= document.getElementById("Email").value ;
                console.log(email);

    
        // Make a request to the API endpoint to validate the login credentials
        fetch(`https://localhost:7108/api/Trainer/Delete`,{
          method:'DELETE',
          headers:{
            'Content-Type':'application/json',
            'email':email,
          }
        })
        //body:JSON.stringify(data)
        .then(response => {
            if (response.status===200) {
                // If the login is successful, display a success message
                alert( 'Trainer Deleted  successfully!!!!!!Hope You Come back Again!!!!');
                window.location.replace('index.html');
            } else {
                // If the login is unsuccessful, display an error message
                alert(' Failed to Delete')
            }
        })
        .catch(error =>console.log(error));
    });
    }

function DeleteSkill(){
    const formE1 = document.querySelector('.form');
    console.log(formE1);
    
    formE1.addEventListener('submit', e => {
        e.preventDefault();
                var skillname=document.getElementById('skillname').value;
                //var email= document.getElementById("Email").value ;
                var email=localStorage.getItem("ParticularEmail");
                console.log(skillname);

    
        // Make a request to the API endpoint to validate the login credentials
        fetch(`https://localhost:7108/api/Skill/Delete`,{
          method:'DELETE',
          headers:{
            'Content-Type':'application/json',
            'email':email,
            'skillname':skillname
          }
        })
        //body:JSON.stringify(data)
        .then(response => {
            if (response.status===200) {
                // If the login is successful, display a success message
                alert( 'Skill Deleted  successful!');
                window.location.replace('Layout.html');
            } else {
                // If the login is unsuccessful, display an error message
                alert(' Failed to Delete')
            }
        })
        .catch(error =>console.log(error));
    });
    }

    
function DeleteCompany(){
    const formE1 = document.querySelector('.form');
    console.log(formE1);
    
    formE1.addEventListener('submit', e => {
        e.preventDefault();
                var cmpName=document.getElementById('cmpName').value;
                //var email= document.getElementById("Email").value ;
                var email=localStorage.getItem("ParticularEmail");
                console.log(cmpName);

    
        // Make a request to the API endpoint to validate the login credentials
        fetch(`https://localhost:7108/api/Company/Delete`,{
          method:'DELETE',
          headers:{
            'Content-Type':'application/json',
            'email':email,
            'cmpName':cmpName
          }
        })
        //body:JSON.stringify(data)
        .then(response => {
            if (response.status===200) {
                // If the login is successful, display a success message
                alert( 'Company Deleted  successful!');
                window.location.replace('Layout.html');
            } else {
                // If the login is unsuccessful, display an error message
                alert(' Failed to Delete')
            }
        })
        .catch(error =>console.log(error));
    });
    }

    function DeleteAvailabilty(){
        const formE1 = document.querySelector('.form');
        console.log(formE1);
        
        formE1.addEventListener('submit', e => {
            e.preventDefault();
                    var day=document.getElementById('day').value;
                    //var email= document.getElementById("Email").value ;
                    var email=localStorage.getItem("ParticularEmail");
                    console.log(day);
                    console.log(email);
    
        
            // Make a request to the API endpoint to validate the login credentials
            fetch(`https://localhost:7108/api/Availability/Delete`,{
              method:'DELETE',
              headers:{
                'Content-Type':'application/json',
                'email':email,
                'day':day
              }
            })
            //body:JSON.stringify(data)
            .then(response => {
                if (response.status===200) {
                    // If the login is successful, display a success message
                    alert( 'Company Deleted  successful!');
                    window.location.replace('Layout.html');
                } else {
                    // If the login is unsuccessful, display an error message
                    alert(' Failed to Delete')
                }
            })
            .catch(error =>console.log(error));
        });
        }
    
    



    function DeleteEducation(){
        const formE1 = document.querySelector('.form');
        console.log(formE1);
        
        formE1.addEventListener('submit', e => {
            e.preventDefault();
            
                    var institution=document.getElementById('institution').value;
                    //var email= document.getElementById("Email").value ;
                    var email=localStorage.getItem("ParticularEmail");
                    console.log(institution);
    
        
            // Make a request to the API endpoint to validate the login credentials
            fetch(`https://localhost:7108/api/Education/Delete`,{
              method:'DELETE',
              headers:{
                'Content-Type':'application/json',
                'email':email,
                'institution':institution
              }
            })
            //body:JSON.stringify(data)
            .then(response => {
                if (response.status===200) {
                    // If the login is successful, display a success message
                    alert( 'Education Deleted  successful!');
                    window.location.replace('Layout.html');
                } else {
                    // If the login is unsuccessful, display an error message
                    alert(' Failed to Delete Education')
                }
            })
            .catch(error =>console.log(error));
        });
        }



function UpdateTrainer(){
    const formE1=document.querySelector('.form');
    //console.log(formE1);
    formE1.addEventListener('submit',event => {
        event.preventDefault();
        const formData=new FormData(formE1);
        const data = Object.fromEntries(formData);
        console.log(data);
        
        fetch('https://localhost:7108/api/Trainer/Update',{
            method:'PUT',
            headers:{
                'Content-Type': 'application/Json'
            },
            body:JSON.stringify(data)
        }).then(Response=>{
            if(Response.status===201){
                alert("Details Updated Successfully");
                window.location.replace('Layout.html');
            }
            else{
                alert("failed to update please try again");
            }
        })
        
           
          .catch(error=>console.log(error));
    });

}



function UpdateSkill(){
    var email=localStorage.getItem("ParticularEmail");
    const formE1=document.querySelector('.form');
    //console.log(formE1);
    formE1.addEventListener('submit',event => {
        event.preventDefault();
        const formData=new FormData(formE1);
        const data = Object.fromEntries(formData);
        console.log(data);
        
        fetch('https://localhost:7108/api/Skill/Update',{
            method:'PUT',
            headers:{
                'Content-Type': 'application/Json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(Response=>{
            if(Response.status===201){
                alert("Skill Updated Successfully");
                window.location.replace('Layout.html');
            }
            else{
                alert("failed to update  Skill please try again");
            }
        })
        
           
          .catch(error=>console.log(error));
    });

}


function UpdateCompany(){
    var email=localStorage.getItem("ParticularEmail");
    const formE1=document.querySelector('.form');
    //console.log(formE1);
    formE1.addEventListener('submit',event => {
        event.preventDefault();
        const formData=new FormData(formE1);
        const data = Object.fromEntries(formData);
        console.log(data);
        
        fetch('https://localhost:7108/api/Company/Update',{
            method:'PUT',
            headers:{
                'Content-Type': 'application/Json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(Response=>{
            if(Response.status===201){
                alert("Company Details Updated Successfully");
                window.location.replace('Layout.html');
            }
            else{
                alert("failed to update  Company please try again");
            }
        })
        
           
          .catch(error=>console.log(error));
    });

}


function UpdateEducation(){
    var email=localStorage.getItem("ParticularEmail");
    const formE1=document.querySelector('.form');
    //console.log(formE1);
    formE1.addEventListener('submit',event => {
        event.preventDefault();
        const formData=new FormData(formE1);
        const data = Object.fromEntries(formData);
        console.log(data);
        
        fetch('https://localhost:7108/api/Education/Update',{
            method:'PUT',
            headers:{
                'Content-Type': 'application/Json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(Response=>{
            if(Response.status===201){
                alert("Education Details Updated Successfully");
                window.location.replace('Layout.html');
            }
            else{
                alert("failed to update  Education please try again!");
            }
        })
        
           
          .catch(error=>console.log(error));
    });

}



function UpdateAvailability(){
    var email=localStorage.getItem("ParticularEmail");
    const formE1=document.querySelector('.form');
    //console.log(formE1);
    formE1.addEventListener('submit',event => {
        event.preventDefault();
        const formData=new FormData(formE1);
        const data = Object.fromEntries(formData);
        console.log(data);
        
        fetch('https://localhost:7108/api/Availability/Update',{
            method:'PUT',
            headers:{
                'Content-Type': 'application/Json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(Response=>{
            if(Response.status===201){
                alert("Trainer Availability Details Updated Successfully");
                window.location.replace('Layout.html');
            }
            else{
                alert("failed to update  trainer availability please try again!");
            }
        })
        
           
          .catch(error=>console.log(error));
    });

}

function GetTrainerByDay()
{
    const formE1 = document.querySelector('.form');
    console.log(formE1)
    
    formE1.addEventListener('submit', e => {
        e.preventDefault();
    var day=document.getElementById('day').value;
    console.log(day);

fetch('https://localhost:7108/api/Filter/GetTrainerByDay',{
  method:'GET',
  headers:{
    'Content-Type':'application/json',
    'day':day
    
  }
})
.then(response=>{
    if(response.ok){
        return response.json();
    }
    else{
        alert("No trainer available on this day Please search on other day");
    }
})
.then(data=>{
    data.forEach(element => {
        const markup=`<div class="card"><h5>Name:  ${element.name} </h5><p>Email:  ${element.email}</p>
        <p>Gender: ${element.gender}</p> <p class="card-text" >Age: ${element.age} </p><p>Phone_Number: ${element.phoneNumber}</p>
        <p>City:${element.city}</p><p> ZipCode:${element.zipcode}</p></div>`;
        document.querySelector('div').insertAdjacentHTML('beforeend',markup);
    });
})
})
}
function GetTrainerBySkillName()
{
    const formE1 = document.querySelector('.form');
    console.log(formE1)
    
    formE1.addEventListener('submit', e => {
        e.preventDefault();
    var skillname=document.getElementById('skillname').value;
    //console.log(day);

fetch('https://localhost:7108/api/Filter/GetTrainerBySkillName',{
  method:'GET',
  headers:{
    'Content-Type':'application/json',
    'skillname':skillname
    
  }
})
.then(response=>{
    if(response.ok){
        return response.json();
    }
    else{
        alert("No trainer found with this skill");
    }
})
.then(data=>{
    data.forEach(element => {
        const markup=`<div class="card"><h5>Name:  ${element.name} </h5><p>Email:  ${element.email}</p>
        <p>Gender: ${element.gender}</p> <p class="card-text" >Age: ${element.age} </p><p>Phone_Number: ${element.phoneNumber}</p>
        <p>City:${element.city}</p><p> ZipCode:${element.zipcode}</p></div>`;
        document.querySelector('div').insertAdjacentHTML('beforeend',markup);
    });
})
})
}

function GetTrainerByExperience()
{
    const formE1 = document.querySelector('.form');
    console.log(formE1)
    
    formE1.addEventListener('submit', e => {
        e.preventDefault();
    var experience=document.getElementById('experience').value;
    //console.log(day);

fetch('https://localhost:7108/api/Filter/GetTrainerByExperience',{
  method:'GET',
  headers:{
    'Content-Type':'application/json',
    'experience':experience
    
  }
})
.then(response=>{
    if(response.ok){
        return response.json();
    }
    else{
        alert("No trainer found with this experience");
    }
})
.then(data=>{
    data.forEach(element => {
        const markup=`<div class="card"><h5>Name:  ${element.name} </h5><p>Email:  ${element.email}</p>
        <p>Gender: ${element.gender}</p> <p class="card-text" >Age: ${element.age} </p><p>Phone_Number: ${element.phoneNumber}</p>
        <p>City:${element.city}</p><p> ZipCode:${element.zipcode}</p></div>`;
        document.querySelector('div').insertAdjacentHTML('beforeend',markup);
    });
})
})
}

function GetTrainerByHourlyPay()
{
    const formE1 = document.querySelector('.form');
    console.log(formE1)
    
    formE1.addEventListener('submit', e => {
        e.preventDefault();
    var hourlyrate1=document.getElementById('hourlyRate1').value;
    console.log(hourlyrate1);
    var hourlyrate2=document.getElementById('hourlyRate2').value;
    console.log(hourlyrate2);

fetch('https://localhost:7108/api/Filter/GetTrainerByHourlyRate',{
  method:'GET',
  headers:{
    'Content-Type':'application/json',
    'hourlyRate1':hourlyrate1,
    'hourlyRate2':hourlyrate2
    
  }
})
.then(response=>{
    if(response.ok){
        return response.json();
    }
    else{
        alert("no trainer found");
    }
})
.then(data=>{
    data.forEach(element => {
        const markup=`<div class="card"><h5>Name:  ${element.name} </h5><p>Email:  ${element.email}</p>
        <p>Gender: ${element.gender}</p> <p class="card-text" >Age: ${element.age} </p><p>Phone_Number: ${element.phoneNumber}</p>
        <p>City:${element.city}</p><p> ZipCode:${element.zipcode}</p></div>`;
        document.querySelector('div').insertAdjacentHTML('beforeend',markup);
    });
})
})
}


    
    
    



    
    





    
    


    
    
    



    
    





    
    
    



    
    












    
    



