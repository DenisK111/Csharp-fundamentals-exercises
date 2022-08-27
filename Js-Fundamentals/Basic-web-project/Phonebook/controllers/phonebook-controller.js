const phonebook = require('../phonebook');
const Contact = require('../models/Contact');
module.exports = {
  index: (req, res) => {
    res.render('index',{
    contacts: phonebook.getPhoneBook()});
    
  },
  addPhonebookPost:(req, res) => {
    phonebook.addContact(new Contact(req.body.name,req.body.number));
    res.redirect('/');
  }
}