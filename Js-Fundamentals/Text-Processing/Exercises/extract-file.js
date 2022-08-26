function extractFileName(word){
    let fileName = word.substring(word.lastIndexOf('\\')+1);
    let fileExtension = fileName.substring(fileName.lastIndexOf('.')+1);
    let file = fileName.substring(0,fileName.length - fileExtension.length - 1);

    console.log(`File name: ${file}`);
    console.log(`File extension: ${fileExtension}`);
}

extractFileName('C:\\Internal\\training-internal\\Template.pptx');