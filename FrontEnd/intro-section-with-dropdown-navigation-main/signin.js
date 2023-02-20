// function validate() {
//     // document.getElementById('getlogin').addEventListener("click", function(event){
//     //     event.preventDefault()
//     //  });

//     var email = document.getElementById("email");
//     var password = document.getElementById("password");
//     var validRegex = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
//     var passwordRegex = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,16}$/;
//     if (email.value == "" || password.value == "")
//     {
//         alert("No blank values allowed");

//         return false;
//     }
//     if (email.value.match(validRegex))
//     {
//         if (password.value.match(passwordRegex))
//         {
//             // return true;
//             CheckSignIn();
//         }
            
//         else{
//             alert("Password must be atleast of length 8, must contain a special character and a number!!");
//             // return false;
//         }
        
//     }
//     else{
//         alert("Email incorrect");
//         // return false;
//     }
// // });
// }


//     var email = document.getElementById("email").value;
//     var password = document.getElementById("password").value;
//     fetch("https://localhost:7241/api/UserTable/GetUserById?" + new URLSearchParams({
//         email : email,
//         password : password
//     }),
//     // adding method type
//     {
//         method: "GET",

//         //ADDING HEADERS
//         headers: {
//             "Content-type": "application/json; charset=UTF-8",
//         },
//     })
//     .then((response) => console.log(response))
//     .then((response) => {
//         if (response.status == 200)
//         {
//             alert("Logged In Successful.");
//             window.location.href = "../displaymenu/display.html";
//         }
//         else{
//             alert("Please check your credentials");
//         }
//     })
//     .then((response) => response.json())
    // .then(json => console.log(json))
    // const form1 = document.querySelector('form');
    // form1.addEventListener('submit', event => {
    //     event.preventDefault();
    //     const formData = new FormData(form1);
    //     let mail = formData.get('email');
    //     let pwd = formData.get('password');

    //     const data = Object.fromEntries(formData);
    //     console.log(data);

    //     fetch('https://localhost:7241/api/UserTable/GetUserById?' + new URLSearchParams({
    //         email : mail,
    //         password : pwd
    //     }),
    //     {
    //         method: "GET",
    //         headers: {
    //             'Content-type' : "application/json; charset=UTF-8",
    //         }
    //     })
    //     .then(res => res.json())
    //       .then(data => console.log(data))
    //       .catch(error => console.log(error));
    // });
    // console.log('Hello');
    // // console.log(fetch('https://localhost:7241/api/UserTable/GetUserById?'));
    // fetch('https://localhost:7241/api/UserTable/GetUserById?')
    // .then(res => console.log(res))

    async function CheckSignIn() {
    document.getElementById('getlogin').addEventListener("click", function(event){
        event.preventDefault()
     });
     let myname = document.getElementById("name").value;
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
   await fetch("https://localhost:7241/api/UserTable/GetUserById?" + new URLSearchParams({
        name: myname,
        email: email,
        password: password
      }), {
        // Adding method type
        method: "GET",
    
        // Adding headers to the request
        headers: {
          "Content-type": "application/json",
        },
      })
      .then((response) => {if(response.status == 200){
         localStorage.setItem("myemail", email)
         localStorage.setItem("mypassword",password)
         localStorage.setItem("myname", myname)
        alert("Login successful.");
        console.log("Successful");
        window.location.href = "../displaymenu/display.html"
      }
        else{
            console.log("Failed");
            alert("Login failed");
        }})
      .then((response) => response.json())
      .then((json) => {if(json != null){
        localStorage.setItem("newAllUsers", JSON.stringify(json))
        
      }})

 }

 async function viewUserTable() {
  //var d = "Name:<br><input type='text' name='name' id='name'><br>Email:<br><input type='email' name='email'>";
  
  //document.getElementById('viewut').addEventListener("click", function(event){
      //event.preventDefault()
   //});
   let email = localStorage.getItem('myemail');
   let password=localStorage.getItem('mypassword')
   console.log(email);
   await fetch("https://localhost:7241/api/UserTable/GetUserById?" + new URLSearchParams({
        
        email: email,
        password: password
      }), {
        // Adding method type
        method: "GET",
    
        // Adding headers to the request
        headers: {
          "Content-type": "application/json",
        },
      })
      .then((response) => {if(response.ok){
      }
        })
      .then(data => {
        console.log(data);
        const mrku=`<ul>Email:${data.emailId} Name:${data.name}  </ul>`
        document.querySelector('ul').insertAdjacentHTML('beforeend',mrku);
      })

  }
    
  async function viewDetails() {
    //var d = "Name:<br><input type='text' name='name' id='name'><br>Email:<br><input type='email' name='email'>";
    
    //document.getElementById('viewut').addEventListener("click", function(event){
        //event.preventDefault()
     //});
     let email = localStorage.getItem('myemail');
     let password=localStorage.getItem('mypassword')
     console.log(email);
     await fetch("https://localhost:7241/api/Details/GetDetails?" + new URLSearchParams({
          
          email: email,
          password: password
        }), {
          // Adding method type
          method: "GET",
      
          // Adding headers to the request
          headers: {
            "Content-type": "application/json",
          },
        })
        .then((response) => {if(response.ok){
          return response.json();
          //  localStorage.setItem("email", myemail)
          //  //localStorage.setItem()
          // alert("Login successful.")
          // console.log("Successful");
          // window.location.href = "../displaymenu/display.html"
        }
        
          })
        // .then((response) => response.json())
        // .then((json) => {if(json != null){
        //   localStorage.setItem("newAllUsers", JSON.stringify(json))
          
        // }})
        .then(data => {
          console.log(data);
          console.log(data.fullName);
          console.log(data.gender);
          const mrku=`<ul>UserID:${data.userId} FullName:${data.fullName} Gender:${data.gender} Address:${data.address}
          AboutMe:${data.aboutMe} PhoneNumber : ${data.phoneNo} Website : ${data.website} </ul>`
          document.querySelector('ul').insertAdjacentHTML('beforeend',mrku);
          
        })
  
    }
     
    async function viewSkills() {
      //var d = "Name:<br><input type='text' name='name' id='name'><br>Email:<br><input type='email' name='email'>";
      
      //document.getElementById('viewut').addEventListener("click", function(event){
          //event.preventDefault()
       //});
       let email = localStorage.getItem('myemail');
       let password=localStorage.getItem('mypassword')
       console.log(email);
       await fetch("https://localhost:7241/api/Skills/GetSkills" + new URLSearchParams({
            
            email: email,
            password: password
          }), {
            // Adding method type
            method: "GET",
        
            // Adding headers to the request
            headers: {
              "Content-type": "application/json",
            },
          })
          .then((response) => {if(response.ok){
            return response.json();
            //  localStorage.setItem("email", myemail)
            //  //localStorage.setItem()
            // alert("Login successful.")
            // console.log("Successful");
            // window.location.href = "../displaymenu/display.html"
          }
          
            })
          // .then((response) => response.json())
          // .then((json) => {if(json != null){
          //   localStorage.setItem("newAllUsers", JSON.stringify(json))
            
          // }})
          .then(data => {
            console.log(data);
            const mrku=`<ul>UserID:${data.userId} Skill-1 : ${data.skill1} Skill-2 : ${data.skill2} Skill-3 : ${data.skill3} </ul>`
            document.querySelector('ul').insertAdjacentHTML('beforeend',mrku);
          })
    
      }

      async function viewExperience() {
        //var d = "Name:<br><input type='text' name='name' id='name'><br>Email:<br><input type='email' name='email'>";
        
        //document.getElementById('viewut').addEventListener("click", function(event){
            //event.preventDefault()
         //});
         let email = localStorage.getItem('myemail');
         let password=localStorage.getItem('mypassword')
         console.log(email);
         await fetch("https://localhost:7241/api/Experience/GetExperienceDetails" + new URLSearchParams({
              
              email: email,
              password: password
            }), {
              // Adding method type
              method: "GET",
          
              // Adding headers to the request
              headers: {
                "Content-type": "application/json",
              },
            })
            .then((response) => {if(response.ok){
              return response.json();
              //  localStorage.setItem("email", myemail)
              //  //localStorage.setItem()
              // alert("Login successful.")
              // console.log("Successful");
              // window.location.href = "../displaymenu/display.html"
            }
            
              })
            // .then((response) => response.json())
            // .then((json) => {if(json != null){
            //   localStorage.setItem("newAllUsers", JSON.stringify(json))
              
            // }})
            .then(data => {
              console.log(data);
              
              const mrku=`<ul> company-1 : ${data.company1} company-2 : ${data.company2} company-3 : ${data.company3} </ul>`
              document.querySelector('ul').insertAdjacentHTML('beforeend',mrku);
            })
      
        }

        //add details
        async function viewEducation() {
          let email = localStorage.getItem('myemail');
          let password=localStorage.getItem('mypassword');
          await fetch("https://localhost:7241/api/Skills/GetEducationDetails?" + new URLSearchParams({
              
              email: email,
              password: password
            }), {
              // Adding method type
              method: "GET",
          
              // Adding headers to the request
              headers: {
                "Content-type": "application/json",
              },
            })
            .then((response) => {if(response.ok){
              return response.json();
              //  localStorage.setItem("email", myemail)
              //  //localStorage.setItem()
              // alert("Login successful.")
              // console.log("Successful");
              // window.location.href = "../displaymenu/display.html"
            }
            
              })
            // .then((response) => response.json())
            // .then((json) => {if(json != null){
            //   localStorage.setItem("newAllUsers", JSON.stringify(json))
              
            // }})
            .then(data => {
              console.log(data);
              const mrku=`<ul> company-1 : ${data.company1} company-2 : ${data.company2} company-3 : ${data.company3} </ul>`
              document.querySelector('ul').insertAdjacentHTML('beforeend',mrku);
            })
      
        }
        
  async function addDetailsTable() {
    document.getElementById('userDetForm').addEventListener('submit', function(event){
      event.preventDefault()
   });
   console.log("Hello");
          let email = localStorage.getItem('myemail');
          let password=localStorage.getItem('mypassword');
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

async function updateusertable() {
      console.log("Hello");
      const handleUpdate = document.getElementById("modifyEducation");

      handleUpdate.addEventListener("submit" , event =>{
          event.preventDefault();
      });
      let email = localStorage.getItem('myemail');
        let password=localStorage.getItem('mypassword');
        let name = localStorage.getItem('myname');
      
      console.log(email);
      console.log(password);
      console.log(name);
      // get details of the user from database
      await fetch("https://localhost:7241/api/UserTable/GetUserById?" + new URLSearchParams({
        
        email: email,
        password: password
      }), {
        // Adding method type
        method: "GET",
    
        // Adding headers to the request
        headers: {
          "Content-type": "application/json",
        },
       }).then(res=>{ 
        
        console.log(res);
        return res.json()})
       .then((data=> {
        document.getElementById("myname").value = data.name;
        document.getElementById("mypassword").value = data.password;
        console.log(data.password)}));

      
        
      //   return response.json();
      //   //  localStorage.setItem("email", myemail)
      //   //  localStorage.setItem("")
      //   // alert("Login successful.")
      //   // console.log("Successful");
      //   // window.location.href = "../displaymenu/display.html"
        
       }
       async function updateusertablemethod() {
      
        const handleUpdate = document.getElementById("modifyEducation");
  
        handleUpdate.addEventListener("submit" , event =>{
            event.preventDefault();
        });
          let email = localStorage.getItem('myemail');
          let password=localStorage.getItem('mypassword');
          let name = localStorage.getItem('myname');
        
           let myname = document.getElementById("myname").value;
           let myemail = document.getElementById("myemail").value;
           let mypassword = document.getElementById("mypassword").value;
           console.log(mypassword + email + myname)

          
        // get details of the user from database
        await fetch("https://localhost:7241/api/UserTable/UpdateUserTable?" + new URLSearchParams({
          email: email,
        }), {
          // Adding method type
          method: "PUT",
          body: JSON.stringify({
            "name": myname,
            "email": "string",
            "password": mypassword
          }),
          // Adding headers to the request
          headers: {
            "Content-type": "application/json",
          },
         }).then(res=>{ {if(res.ok){
          console.log(res);
          alert("Working");}else{
            alert("Error");
         }};
        });
      }  
    //       console.log(res);
    //       return res.json()})
    //     //  .then((data=> {
    //     //   document.getElementById("myname").value = data.name;
    //     //   document.getElementById("mypassword").value = data.password;
    //     //   console.log(data.password)}));
    //       .then((response) => }
    //         )
          
    // }

async function updatedetails() {
  console.log("Hello");
  const handleUpdate = document.getElementById("modifyEducation");
  let email = localStorage.getItem('myemail');
          let password=localStorage.getItem('mypassword');
          let name = localStorage.getItem('myname');

  handleUpdate.addEventListener("submit" , event =>{
      event.preventDefault();
  });
  let fullname = document.getElementById('myname').value;
  let address = document.getElementById('myaddr').value;
  let aboutme = document.getElementById('aboutme').value;
  let phoneNo = document.getElementById('phnno').value;  
  let website = document.getElementById('website').value;
  // console.log(email);
  // console.log(password);
  // console.log(name);
  // get details of the user from database
  await fetch("https://localhost:7241/api/Details/GetDetails?" + new URLSearchParams({
    email: email
  }), {
    // Adding method type
    method: "GET",

    // Adding headers to the request
    headers: {
      "Content-type": "application/json",
    },
  }).then((res) => res.json())
  .then((json) => console.log(json))
     .then(data => {
       console.log(data);
       console.log(data.fullName);
       //console.log(data.name);
  })
    
}

async function deleteuser() {
  let email = localStorage.getItem('myemail');
          let password=localStorage.getItem('mypassword');
          let name = localStorage.getItem('myname');
  await fetch("https://localhost:7241/api/Delete/DeleteTrainer?" + new URLSearchParams({
    email: email
  }), {
    // Adding method type
    method: "DELETE",

    // Adding headers to the request
    headers: {
      "Content-type": "application/json",
    },
  }).then(res=>{ {if(res.ok){
    console.log(res);
    alert("Working");}else{
      alert("Error");
   }};
  })
       //console.log(data.name);
  }
