var phonebook = [];

function getPhoneBook(){
	return phonebook;
}

function addContact(contact){
	phonebook.push(contact);
}

module.exports={
	getPhoneBook,
	addContact
};