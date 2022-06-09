// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//set variables
const passcodeDisplay = document.getElementById("passcodeDisplay");
const generateBtn = document.getElementById("generateBtn");
const clearBtn = document.getElementById("clearBtn");
let counterDisplay = document.getElementById("counterDisplay");

//create a function that fetches the passcode from the controller on the ASP .NET side
async function getPasscode(){
    const response = await fetch("http://localhost:5218/Home/GeneratePasscode");
    const passcode = await response.json();
    passcodeDisplay.innerHTML = passcode.Passcode;
    counterDisplay.innerHTML = passcode.Counter;
}

//generate our first passcode
getPasscode();

//update passcode when button is clicked
generateBtn.onclick = () => {
    getPasscode();
}

clearBtn.onclick = async () => {
    const response = await fetch("http://localhost:5218/Home/ClearCounter");
    const counter = await response.json();
    counterDisplay.innerHTML = counter;
}