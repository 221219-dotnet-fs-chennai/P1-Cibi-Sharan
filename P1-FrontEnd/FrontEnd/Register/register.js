function validate() {
    // document.getElementById('getlogin').addEventListener("click", function(event){
    //     event.preventDefault()
    //  });
    console.log('Hello');
    var email = document.getElementById("email");
    var password = document.getElementById("password");
    var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    var passwordRegex = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,10}$/;
    if (email.value == "" || password.value == "")
    {
        alert("No blank values allowed");

        return false;
    }
    if (email.value.match(validRegex))
    {
        if (password.value.match(passwordRegex))
        {
            // return true;
            RegisterUser();
        }
            
        else{
            alert("Password must be of length 6-10, must contain a special character and a number!!");
            // return false;
        }
        
    }
    else{
        alert("Email incorrect");
        // return false;
    }
// });
}

async function RegisterUser() {
    document.getElementById('getregistered').addEventListener("click", function(event){
        event.preventDefault()
     });
    console.log("Hello");
    let myname = document.getElementById("name").value;
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    
    // function PassEmail()
    // {
    //     return email;
    // }
//     console.log(email);
   await fetch("https://localhost:7241/api/UserTable/SignUp", {
        // Adding method type
        method: "POST",

        body: JSON.stringify({
                "name": myname,
                "Email": email,
                "password": password,
                "detail": null,
                "education": null,
                "experience": null,
                "skill": null
              
        }),
    
        // Adding headers to the request
        headers: {
          "Content-type": "application/json; charset=UTF-8",
        },
      })
      .then((response) => {if(response.ok){
        // localStorage.setItem("email", email)
        alert("Signup successful.")
        console.log("Successful");
         window.location.href = "../SignIn/signin.html";
         localStorage.setItem("myemail", email)
         localStorage.setItem("mypassword",password)
         localStorage.setItem("myname", myname)
      }
      else if(response.status == 401){alert("invalid credentials, try again or try signing up!")}
        })
    //   .then((response) => response.json())
}

async function addDetailsTable() {
    document.getElementById('userDetForm').addEventListener('submit', function(event){
      event.preventDefault()
   });
   console.log("Hello");
          let email = localStorage.getItem('myemail');
          let password=localStorage.getItem('mypassword');
          let name = localStorage.getItem('myname');
  console.log("Hello");
  let myname = document.getElementById("fullname").value;
  let gender = document.getElementById("gender").value;
  let address = document.getElementById("address").value;
  let aboutme = document.getElementById("aboutme").value;
  let phoneNo = document.getElementById("phn").value;
  let website = document.getElementById("website").value;
  
  
 await fetch("https://localhost:7241/api/Details/Add?" + new URLSearchParams({
              
      email: email,
      password: password
      }),{
      // Adding method type
      method: "POST",

      body: JSON.stringify({
        "fullName": myname,
        "gender": gender,
        "address": address,
        "aboutMe": aboutme,
        "phoneNo": phoneNo,
        "email": email,
        "website": website
      }),
  
      // Adding headers to the request
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
    .then((response) => {if(response.ok){
      // localStorage.setItem("email", email)
      console.log("Added details successfully..");
       window.location.href = "../SignIn/skill.html";
    }
    else if(response.status == 401){alert("invalid credentials, try again or try signing up!")}
    else{
      alert("I dont know what to do..");
    }
      })
      
  //   .then((response) => response.json())
}
 
async function addSkillsTable() {
  document.getElementById('userSkillForm').addEventListener('submit', function(event){
    event.preventDefault()
 });
 console.log("Hello");
        let email = localStorage.getItem('myemail');
        let password=localStorage.getItem('mypassword');
console.log("Hello");
let skill1 = document.getElementById('skill1').value;
let skill2 = document.getElementById('skill2').value;
let skill3 = document.getElementById('skill3').value;
// function PassEmail()
// {
//     return email;
// }
//     console.log(email);
await fetch("https://localhost:7241/api/Skills/AddSkills/" +email,{
    // Adding method type
    method: "POST",

    body: JSON.stringify({
      "skilL_1": skill1,
      "skilL_2": skill2,
      "skilL_3": skill3
    }),

    // Adding headers to the request
    headers: {
      "Content-type": "application/json; charset=UTF-8",
    },
  })
  .then((response) => {if(response.ok){
    // localStorage.setItem("email", email)
    console.log("Added skills successfully..");
     window.location.href = "../SignIn/experience.html";
  }
  else if(response.status == 401){alert("invalid credentials, try again or try signing up!")}
  else{
    alert("I dont know what to do..");
  }
    })
    
//   .then((response) => response.json())
}

async function addExperienceTable() {
  document.getElementById('userExperienceForm').addEventListener('submit', function(event){
    event.preventDefault()
 });
 console.log("Hello");
        let email = localStorage.getItem('myemail');
        let password=localStorage.getItem('mypassword');
console.log("Hello");
let company1 = document.getElementById('c1').value;
let company2 = document.getElementById('c2').value;
let company3 = document.getElementById('c3').value;
// function PassEmail()
// {
//     return email;
// }
//     console.log(email);
await fetch("https://localhost:7241/api/Experience/Add/" +email,{
    // Adding method type
    method: "POST",

    body: JSON.stringify({
      "companY1": company1,
      "companY2": company2,
      "companY3": company3
    }),

    // Adding headers to the request
    headers: {
      "Content-type": "application/json; charset=UTF-8",
    },
  })
  .then((response) => {if(response.ok){
    // localStorage.setItem("email", email)
    console.log("Added experience successfully..");
     window.location.href = "../SignIn/education.html";
  }
  else if(response.status == 401){alert("invalid credentials, try again or try signing up!")}
  else{
    alert("I dont know what to do..");
  }
    })
}

async function addEducationTable() {
  document.getElementById('userEducationForm').addEventListener('submit', function(event){
    event.preventDefault()
 });
 console.log("Hello");
        let email = localStorage.getItem('myemail');
        let password=localStorage.getItem('mypassword');
console.log("Hello");
let registerNo = document.getElementById('regno').value;
let collegeName = document.getElementById('clgname').value;
let stream = document.getElementById('stream').value;
let branch = document.getElementById('branch').value;
let percentage = document.getElementById('percentage').value;
let startyear = document.getElementById('startyear').value;
let endyear = document.getElementById('endyear').value;
// function PassEmail()
// {
//     return email;
// }
//     console.log(email);
await fetch("https://localhost:7241/api/Education/AddEducation?" +new URLSearchParams({             
email: email
}),{
    // Adding method type
    method: "POST",

    body: JSON.stringify({
      "registeR_NO": registerNo,
      "collegE_NAME": collegeName,
      "stream": stream,
      "branch": branch,
      "percentage": percentage,
      "starT_YEAR": startyear,
      "enD_YEAR": endyear
    }),

    // Adding headers to the request
    headers: {
      "Content-type": "application/json; charset=UTF-8",
    },
  })
  .then((response) => {if(response.ok){
    // localStorage.setItem("email", email)
    console.log("Added education successfully..");
     window.location.href = "../displaymenu/display.html";
  }
  else if(response.status == 401){alert("invalid credentials, try again or try signing up!")}
  else{
    alert("I dont know what to do..");
  }
    })
}