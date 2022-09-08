console.log("Javascript connected!!")

//	//Validtion Code For Inputs

var goBackButton = document.getElementById('goBackButton');
var namee = document.getElementById('name');
var pin = document.getElementById('pin');
var email = document.getElementById('email');
var password = document.getElementById('password');


var pin_error = document.getElementById('pin_error');
var name_error = document.getElementById('name_error');
var email_error = document.getElementById('email_error');
var pass_error = document.getElementById('pass_error');


var email_valid = false
var pass_valid = false
var name_valid = false
var pin_valid = false

console.log(pin)
console.log(namee)
console.log(email)
console.log(password)

//goBackButton.addEventListener('click', window.location.replace("https://localhost:44350/Employee/Home"));


if (email != null)
	email.addEventListener('textInput', email_Verify);
else
	console.log('email null')

if (password != null)
	password.addEventListener('textInput', pass_Verify);
else
	console.log('password null')

pin.addEventListener('textInput', pin_Verify);

namee.addEventListener('textInput', name_Verify);

goBackButton.addEventListener('click', () => {
	window.location("https://www.google.com")
})


function validated() {
	//Check if pin is valid
	if (password.value.length < 6) {
		password.style.border = "1px solid red";
		pass_error.style.display = "block";
		password.focus();
		return false;
	}
}

function email_Verify() {
	return email_valid;
}
function pass_Verify() {
	return true;
}
function pin_Verify() {
	return true;
}
function name_Verify() {
	return evName;
}

function valid() {
	sendEmail()
	if (email_Verify() && pass_Verify() && pin_Verify() && name_Verify()) {
		console.log("Verfied all")
		


		return true;
	}
}

function sendEmail(){
    Email.send({
        
      Host: "smtp.elasticemail.com", 
		Username: "tanim.pro@gmail.com",
      Password: "tanim998tt",
      To: "190104025@aust.edu",
		From: "tanim.pro@gmail.com",
      Subject: `Just messaged you from the website form`,
      Body: `Name: `,
    }).then((success) => {
     
      alert("message sent successfully. Please check the spam folder in your mail.");
    }).catch((error) => {
        
      alert("error sending message");
    })
  }

function epass(ch) {
	console.log("This is epass: ", ch)
	pass_valid = true;

	if (password.value.length < 6) {
		password.style.border = "1px solid red";
		pass_error.textContent = "Password is is too short!"
		pass_error.style.display = "block";
		password.focus();
		pass_valid = false;
	}
	else if (pin.value.length > 32) {
		password.style.border = "1px solid red";
		pass_error.textContent = "Password is too long!"
		pass_error.style.display = "block";
		password.focus();
		pass_valid = false;
	}
	else {
		password.style.border = "1px solid green";
		pass_error.style.display = "none";
		pass_valid = true;
	}
}

function evName(ch) {
	console.log("evName: ", ch)

	var regName = /^[a-zA-Z]+( [a-zA-Z]+)+$/;

	if (!regName.test(ch)) {
		namee.style.border = "1px solid red";
		name_error.style.display = "block";
		name_error.textContent = "Name is not valid yet.."
		namee.focus();
		name_valid = false;
	} else {
		name_error.style.display = "none";
		name_valid = true;
		console.log("Name valid")
		namee.style.border = "1px solid green";
	}
}

function evPin(ch) {
	console.log("epin: ", ch)

	if (pin.value.length == 6) {
		pin.style.border = "1px solid green";
		pin_error.textContent = "Pin is shorter than expected!"
		pin_error.style.display = "none";
		pin.focus();
		pin_valid = true;
	}
	else if (pin.value.length < 6) {
		pin.style.border = "1px solid red";
		pin_error.textContent = "Pin is shorter than expected!"
		pin_error.style.display = "block";
		pin.focus();
		pin_valid = false;
	}
	else if (pin.value.length > 6) {
		pin.style.border = "1px solid red";
		pin_error.textContent = "Pin is larger than expected!"
		pin_error.style.display = "block";
		pin.focus();
		pin_valid = false;
	}
}

function ev(ch) {
	console.log("This is ev: ", ch)

	var validRegex = /^w+([.-]?w+)*@w+([.-]?w+)*(.w{2,3})+$/;
	const regex_pattern = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

	if (regex_pattern.test(email.value)) {
		email_error.style.display = "none";
		email_valid = true;
		email.style.border = "1px solid green";
	}
	else {
		email.style.border = "1px solid red";
		email_error.style.display = "block";
		email_error.textContent = "Email is not valid yet.."
		email.focus();
		email_valid = false;
	}
}


