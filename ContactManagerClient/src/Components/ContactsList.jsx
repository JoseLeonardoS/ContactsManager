import React, { useEffect, useState } from 'react';
import api from '../Services/api';
import ContactBlock from './ContactBlock';

const ContactList = () => {
    const [contacts, setContacts] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchContacts = async () => {
            try {
                const response = await api.get('/listar-contatos');
                setContacts(response.data);
            } catch (error) {
                console.error('Erro ao buscar os contatos:', error);
                setError('Erro ao buscar os contatos');
            } finally {
                setLoading(false);
            }
        };

        fetchContacts();
    }, []);

    if (loading) {
        return <p>Carregando...</p>;
    }

    if (error) {
        return <p>{error}</p>;
    }

    return (
        <div>
            <h2>Lista de Contatos</h2>
            <ul>
                {
                    contacts.data.map((contact) => (
                        <li key={contact.id}>
                            <ContactBlock 
                                id={contact.id} 
                                name={contact.name} 
                                email={contact.email} 
                                phone={contact.phone}
                            />
                        </li>
                    ))
                }
            </ul>
        </div>
    );
};

export default ContactList;
