
function load() {
  var requstURL = 'https://localhost:7185/ToDo';
  var items = document.getElementById('items');

  function sendRequest(method, url) {
    return fetch(url).then(response => {

      return response.json()
    })
  }

  sendRequest('GET', requstURL)
    .then(data => { 
      items.innerHTML="";
      data.forEach(element => addRow(element)) }
    )
    .catch(err => console.log(err))
}

function addRow(item) {
  const div = document.createElement('div');

  div.className = 'row';
var checkbox= `  <input onchange="check('`+ item.id + `',this.checked)" type="checkbox"`;
if(item.done){
  checkbox+='checked'

}
checkbox+=' >';
  div.innerHTML = checkbox+`
  
    <div>Name:&nbsp;&nbsp;`+ item.name + `</div>
    <div>Discription:&nbsp;&nbsp;`+ item.discription + `</div>
    <label> 
      
    </label>
    <input type="button" value="delete" onclick="removeRow('`+ item.id + `')" />
  `;

  document.getElementById('items').appendChild(div);
}
function addItem() {
  console.log(document.getElementById("Name").value);
  console.log(document.getElementById("Description").value)
  var result = {
    description: document.getElementById("Description").value,
    name: document.getElementById("Name").value
  }

  fetch("https://localhost:7185/ToDo", {
    method: "POST",
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(result)

  }).
    then(res => {
      load();
    });


}

function removeRow(id) {

  fetch("https://localhost:7185/ToDo?id="+id, {
    method: "DELETE",
    headers: { 'Content-Type': 'application/json' }
    

  }).
    then(res => {
      load();
    });
}

function check(id,done) {

  fetch("https://localhost:7185/ToDo?id="+id+'&done='+done, {
    method: "PATCH",
    headers: { 'Content-Type': 'application/json' }

  }).
    then(res => {
      load();
    });
}
load();
document.getElementById("registrbutton").addEventListener('click',function(){
    var request = {
        "email": document.getElementById("Login").value,
       "password":document.getElementById("Password").value

    }
    fetch("/ToDoRegistr", {
        method: "POST",
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(request)

    });
        

});