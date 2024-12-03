import api from "../Services/api";
import { useState } from "react";


const ContactForm = () => {

    const [name, setName] = useState('')
    const [email, setEmail] = useState('')
    const [phone, setPhone] = useState('')

    const handleSubmit = async (e) => {
        e.preventDefault();
        const data = {
            name: name,
            email: email,
            phone: phone
        }

        const response = await api.post("criar-contato", data);
        console.log(response.data)
    }

    return (
        <form onSubmit={handleSubmit} >
            <input
                type="text"
                placeholder="Nome"
                value={name}
                onChange={(e) => setName(e.target.value)}
                required
            />
            <input
                type="email"
                placeholder="Email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
            />
            <input
                type="phone"
                placeholder="Phone"
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
                required
            />
            <button type="submit" >Criar Contato</button>
        </form>
    )
}

export default ContactForm;