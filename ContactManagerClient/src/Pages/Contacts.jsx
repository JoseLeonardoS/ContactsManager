import { useState } from "react"
import ContactForm from "../Components/ContactForm"
import ContactList from "../Components/ContactsList"

function Contacts(){

    return (
        <>
            <h1>Lista de Contatos</h1>
            <p>Página com lista de contatos</p>
            <ContactForm />
            <ContactList  />
        </>
    )
}

export default Contacts
