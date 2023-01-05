function editElement(htmlElement, match, replacer) {
    while (htmlElement.textContent.includes(match)) {
        htmlElement.textContent = htmlElement.textContent.replace(match, replacer)
    }
}
