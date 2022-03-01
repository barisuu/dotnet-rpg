const { json } = require("express/lib/response");

async function login(username,password){
    var userdata = {username: username, password: password};
    var reqresponse= await request("POST","http://localhost:5000/auth/login","Ignore",1,userdata);
    /*var req = new XMLHttpRequest();
    req.open("POST","http://localhost:5000/auth/login");
    req.setRequestHeader("Content-Type","application/json");
    req.send(JSON.stringify({username: username, password: password}));
    var response =req.responseText;
    req.onreadystatechange=function(){
        if(req.readyState === 4){
            token=JSON.parse(req.response).data;
            if(req.status==200){
                CreateTable();
                document.getElementById("logindiv").style.display = "none";
            }
            else{
                console.log("Bad Req");
            }
        }
    }*/
    if(JSON.parse(reqresponse).success===true){
        console.log(JSON.parse(reqresponse).data);
        window.sessionStorage.setItem("usertoken",JSON.parse(reqresponse).data);
        CreateTable();
        document.getElementById("logindiv").style.display = "none";
    }
    else{
        console.log("Error in login request");
    }
}

async function CreateTable(){
        var reqresponse =await request("GET","http://localhost:5000/character/getall");
            var characters = JSON.parse(reqresponse).data;
            console.log(characters); 
            var col = [];
            for (var i = 0; i < characters.length; i++) {
                for (var key in characters[i]) {
                    if (col.indexOf(key) === -1) {
                        col.push(key);
                    }
                }
            }
            var table = document.createElement("table");

            var tr = table.insertRow(-1);
            for(var i=0;i< col.length;i++){
                var th = document.createElement("th");
                th.innerHTML=col[i];
                tr.appendChild(th);
            }
            for(var i=0;i<characters.length;i++){
                tr = table.insertRow(-1);
                for(var j=0;j<col.length;j++){
                    var tabCell = tr.insertCell(-1);
                    if(col[j]=="weapon"){
                        if(characters[i][col[j]]!=null){
                            tabCell.innerHTML=Object.values(characters[i][col[j]])[0];
                        }
                        else if(characters[i][col[j]]==null){
                            tabCell.innerHTML="Empty";
                        }
                        
                    }
                    else if(col[j]=="skills"){
                        if(characters[i][col[j]].length!=0){
                            tabCell.innerHTML=Object.values(Object.values(characters[i][col[j]])[0])[0];
                        }
                        else if(characters[i][col[j]].length==0){
                            tabCell.innerHTML="Empty";
                        }
                    }
                    else{
                        tabCell.innerHTML=characters[i][col[j]];
                    }
                    if(j==col.length-1){
                        var inputCellCustomize = tr.insertCell(-1);
                        var inputCellDelete= tr.insertCell(-1);
                        var inputCellSubmit = tr.insertCell(-1);

                        var customizeButton = document.createElement("input");
                        var deleteButton= document.createElement("input");
                        var submitButton= document.createElement("input");


                        customizeButton.setAttribute("type", "button");
                        deleteButton.setAttribute("type", "button");
                        submitButton.setAttribute("type","button");

                        customizeButton.setAttribute("value","Customize");
                        deleteButton.setAttribute("value","Remove");
                        submitButton.setAttribute("value","Submit");

                        customizeButton.setAttribute("onclick", "customizeRow(this)");
                        deleteButton.setAttribute("onclick","removeRow(this)");
                        submitButton.setAttribute("onclick","submitRow(this)");
 
                        inputCellCustomize.appendChild(customizeButton);
                        inputCellDelete.appendChild(deleteButton);
                        inputCellSubmit.appendChild(submitButton);
                        inputCellSubmit.style.display="none";
                    }
                    
                }
            }
            var divContainer = document.getElementById("showData");
            divContainer.innerHTML="";
            divContainer.appendChild(table);
}

function customizeRow(customizeButton){
    var myTable = document.getElementById("table");
    var rowNodes = customizeButton.parentNode.parentNode.childNodes;

    //console.log(customizeButton.parentNode.parentNode); //parentElement first element child is names.
    for(var i=1;i<rowNodes.length-4;i++){
        if(i==1){var nameBox = createInputBox(rowNodes,i);        rowNodes[i].innerHTML="";
        rowNodes[i].appendChild(nameBox);};
        if(i==2){var HpBox = createInputBox(rowNodes,i);        rowNodes[i].innerHTML="";
        rowNodes[i].appendChild(HpBox);};
        if(i==3){var StrBox = createInputBox(rowNodes,i);        rowNodes[i].innerHTML="";
        rowNodes[i].appendChild(StrBox);};
        if(i==4){var DefBox = createInputBox(rowNodes,i);        rowNodes[i].innerHTML="";
        rowNodes[i].appendChild(DefBox);};
        if(i==5){var IntBox = createInputBox(rowNodes,i);        rowNodes[i].innerHTML="";
        rowNodes[i].appendChild(IntBox);};
    }

    rowNodes[9].style.display="none";
    rowNodes[10].style.display="none";
    rowNodes[11].style.display="table-cell"
}

async function submitRow(submitButton){
    var myTable = document.getElementById("table");
    var rowNodes = submitButton.parentNode.parentNode.childNodes;
    var submitObj = {
        charId:-1,
        charName:"",
        charHitPoints:-1,
        charStrength:-1,
        charDefense:-1,
        charIntelligence:-1,
       // Weapon:"",
       // Skills:""
    };
    var tableNames = submitButton.parentNode.parentNode.parentNode.firstChild.childNodes;
    var tempText = "testtext";
    const keys =Object.keys(submitObj);
    console.log(Object.keys(submitObj));
    for(var i=0;i<rowNodes.length-4;i++){
        keys.forEach((key, index) => {
            if(key == tableNames[i].firstChild.data){
                if (i==0){
                    submitObj[key]=parseInt(rowNodes[i].firstChild.data);
                }
                else{
                    if(tableNames[i].firstChild.data!="charName"){
                        submitObj[key]=parseInt(rowNodes[i].firstChild.value);
                    }
                    else{
                        submitObj[key]=rowNodes[i].firstChild.value;
                    }
                    console.log(rowNodes[i].firstChild);
                }
            }
        });
    }
    rowNodes[9].style.display="none";
    rowNodes[10].style.display="none";
    rowNodes[11].style.display="table-cell"

    console.log(JSON.stringify(submitObj));
    var req =await request("PUT","http://localhost:5000/character","Authorization","Bearer " + window.sessionStorage.getItem("usertoken"),submitObj);
    console.log(req);
    CreateTable();
}

function createInputBox(rowNodes,i){
    var inputBox = document.createElement("input") ;
    inputBox.setAttribute("type","text");
    inputBox.setAttribute("name",rowNodes[i].firstChild.data);
    inputBox.setAttribute("value",rowNodes[i].firstChild.data);
    inputBox.setAttribute("id","customizable"+i);
    return inputBox;
}

async function removeRow(deleteButton){
    var req =await request("DELETE","http://localhost:5000/character/"+deleteButton.parentNode.parentNode.childNodes[0].firstChild.data,"Authorization","Bearer " + window.sessionStorage.getItem("usertoken"));
    CreateTable();
}

async function addRow(){
    
}

function request(reqmethod,requrl,headerName,headerValue,sendData){
    return new Promise(function (resolve, reject) {
        var request = new XMLHttpRequest();
        if (request) {
            request.open(reqmethod, requrl);
            if(headerName != undefined){
                if(headerName!="Ignore"){
                    request.setRequestHeader(headerName,headerValue);
                }
                request.setRequestHeader("Content-Type","application/json")
            }
            if(sendData != undefined){
                request.send(JSON.stringify(sendData));
            }
            else if(sendData === undefined){
                request.send();
            }
            if (typeof (request.onload) !== undefined) {
                request.onload = function () {
                    resolve(this.response)
                    request = null;
                };
            } else {
                request.onreadystatechange = function () {
                    if (request.readyState === 4) {
                        resolve(this.response)
                        request = null;
                    }
                };
            }
        } else {
            reject("Couldn't make request to database");
        }
    });
}
