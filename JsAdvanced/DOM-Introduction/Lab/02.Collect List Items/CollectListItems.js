function extractText() {
    let result = document.querySelectorAll('li');

    let jsArray = Array.from(result);
    let textarea = document.getElementById('result')

    for (const li of jsArray) {
        textarea.value += `${li.textContent}\r\n`
    }

}