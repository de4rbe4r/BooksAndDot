import {getValue} from "@testing-library/user-event/dist/utils";

let baseUrl = 'http://localhost:5000';

export function getAllBooks() {
    let url = baseUrl + '/api/Books';
    let temp = []
    fetch(url)
        .then(response => response.json())
        .then(data => {
            for (const b in data) {
                temp.push(data[b])
            }
        })
    console.log('temp: ', temp)
    return temp
}

function sendRequest(url) {
    fetch(url).then(response => response.json())
        .then(data => {
            console.log(data);
            //return data;
    });
        
}