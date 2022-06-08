function OddArray(){
    let array = [];

    for (var i = 1; i <= 255; i++){
        if(i%2 != 0){
            array.push(i);
        }
    }

    return array;
}

console.log(OddArray());