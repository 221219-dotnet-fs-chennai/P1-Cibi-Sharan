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
        alert("Login successful.")
        console.log("Successful");
         window.location.href = "../SignIn/signin.html";
      }
      else if(response.status == 401){alert("invalid credentials, try again or try signing up!")}
        })
    //   .then((response) => response.json())
}