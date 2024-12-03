import React, { useState, useEffect } from 'react';
import api from '../Services/api';

const UpdateContact = ({ id }) => {
    const [contact, setContact] = useState({ name: '', email: '', phone: '', imagePath: '' });
    const [message, setMessage] = useState('');

    useEffect(() => {
        const fetchContact = async () => {
            try {
                const response = await api.get(`/listar-contatos`);
                setContact(response.data);
            } catch (error) {
                console.error('Erro ao buscar contato:', error);
            }
        };

        fetchContact();
    }, [id]);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setContact({ ...contact, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await api.put(`/editar-contato/${id}`, contact);
            console.log('Resposta da API:', response.data);
            setMessage('Contato atualizado com sucesso!');
        } catch (error) {
            console.error('Erro ao atualizar contato:', error);
            setMessage('Erro ao atualizar contato, tente novamente.');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                name="name"
                placeholder="Nome"
                value={contact.name}
                onChange={handleInputChange}
                required
            />
            <input
                type="email"
                name="email"
                placeholder="Email"
                value={contact.email}
                onChange={handleInputChange}
                required
            />
            <button type="submit">Atualizar Contato</button>
            {message && <p>{message}</p>}
        </form>
    );
};

export default UpdateContact;