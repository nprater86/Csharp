List<object> testList = new List<object>();

testList.Add(7);
testList.Add(28);
testList.Add(-1);
testList.Add(true);
testList.Add("chair");

for (var i = 0; i < testList.Count; i++){
    Console.WriteLine(testList[i]);
}

int sum = 0;

for (var i = 0; i < testList.Count; i++){
    if (testList[i] is int){
        sum += (int)testList[i];
    }
}

Console.WriteLine(sum);