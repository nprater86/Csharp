// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//make variables for the stats
const fullness = document.getElementById("fullness");
const happiness = document.getElementById("happiness");
const meals = document.getElementById("meals");
const energy = document.getElementById("energy");
const mood = document.getElementById("mood");
const message = document.getElementById("message");
//make variables for the buttons
const feedBtn = document.getElementById("feed");
const playBtn = document.getElementById("play");
const workBtn = document.getElementById("work");
const sleepBtn = document.getElementById("sleep");
const restartBtn = document.getElementById("restart");

//create function to update the stats at top
async function updateStats(){
    const result = await fetch ("http://localhost:5098/Home/Status");
    const dojodachi = await result.json();
    console.log(dojodachi);
    fullness.innerHTML = dojodachi.Fullness;
    happiness.innerHTML = dojodachi.Happiness;
    meals.innerHTML = dojodachi.Meals;
    energy.innerHTML = dojodachi.Energy;
    switch(dojodachi.Mood) {
        case "neutral":
            mood.src="./images/neutral.png";
            break;
        case "angry":
            mood.src="./images/angry.png";
            break;
        case "dead":
            mood.src="./images/dead.png";
            break;
        case "happy":
            mood.src="./images/happy.png";
            break;
        case "tired":
            mood.src="./images/tired.png";
            break;
        case "win":
            mood.src="./images/win.png";
            break;
        case "work":
            mood.src="./images/work.png";
            break;
        case "eat":
            mood.src="./images/eat.png";
            break;
        default:
            mood.src="./images/neutral.png";
    }
}

updateStats();
checkWin();
restartBtn.style.display = "none";

//Actions for the buttons
feedBtn.onclick = async () => {
    const result = await fetch ("http://localhost:5098/Home/Feed");
    const messageResult = await result.json();
    message.innerHTML = messageResult;
    updateStats();
    checkWin();
}

playBtn.onclick = async () => {
    const result = await fetch ("http://localhost:5098/Home/Play");
    const messageResult = await result.json();
    message.innerHTML = messageResult;
    updateStats();
    checkWin();
}

workBtn.onclick = async () => {
    const result = await fetch ("http://localhost:5098/Home/Work");
    const messageResult = await result.json();
    message.innerHTML = messageResult;
    updateStats();
    checkWin();
}

sleepBtn.onclick = async () => {
    const result = await fetch ("http://localhost:5098/Home/Sleep");
    const messageResult = await result.json();
    message.innerHTML = messageResult;
    updateStats();
    checkWin();
}

restartBtn.onclick = async () => {
    const result = await fetch ("http://localhost:5098/Home/Reset");
    const messageResult = await result.json();
    console.log(messageResult);
    message.innerHTML = "This is Dojodachi! Click a button below to start!";
    feedBtn.style.display = "block";
    playBtn.style.display = "block";
    workBtn.style.display = "block";
    sleepBtn.style.display = "block";
    restartBtn.style.display = "none";
    updateStats();
}

//Check Win
async function checkWin(){
    const result = await fetch ("http://localhost:5098/Home/CheckWin");
    const messageResult = await result.json();
    console.log(messageResult);
    if(messageResult == "dead"){
        message.innerHTML = "Oh no! Dojodachi died! Hit restart to try again!";
        feedBtn.style.display = "none";
        playBtn.style.display = "none";
        workBtn.style.display = "none";
        sleepBtn.style.display = "none";
        restartBtn.style.display = "block";

    } else if (messageResult == "win") {
        message.innerHTML = "Congratulations! You won! Hit restart to play again!";
        feedBtn.style.display = "none";
        playBtn.style.display = "none";
        workBtn.style.display = "none";
        sleepBtn.style.display = "none";
        restartBtn.style.display = "block";
    }
}