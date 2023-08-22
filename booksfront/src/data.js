
let baseUrl = 'http://localhost:5000';

function getAllBooks() {
    let url = baseUrl + '/api/Books';
    fetch(url).then(response => response.json())
        .then(data => { 
            return data;
        });
}

function sendRequest(url) {
    fetch(url).then(response => response.json())
        .then(data => {
            console.log(data);
            //return data;
    });
        
}