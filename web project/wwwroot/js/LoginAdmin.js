

function (event) {
    event.preventDefault(); // Prevent the default form submission
    var input1 = document.getElementById("usernameInput").value;
    var input2 = document.getElementById("passwordInput").value;
    var message;
    if (input1 === "" || input2 === "") {
        document.getElementById("message").innerHTML = "Please fill out the fields";
        document.getElementById("message").className = "text-danger"
    }

    else if (input1 === "Admin" && input2 === "Admin" || input1 === "admin" && input2 === "admin") {
        document.getElementById("message").innerHTML = "Logged in Successfully";
        document.getElementById("message").className = "text-success";
        document.getElementById("loginForm").action = "https://www.google.com"; // Set the form action to the desired URL
        document.getElementById("loginForm").submit(); // Submit the form
    } else {
        document.getElementById("message").innerHTML = "Wrong Username or Password";
        document.getElementById("message").className = "text-danger"

    }

}