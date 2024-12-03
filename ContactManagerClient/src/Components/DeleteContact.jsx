import React, { useState } from 'react';
import api from '../Services/api';

const DeleteContact = ({ id }) => {
    const [message, setMessage] = useState('');

    const handleDelete = async () => {
        try {
            await api.delete(`/deletar-contato/${id}`);
            setMessage('Contato deletado com sucesso!');
            console.log(id)
        } catch (error) {
            console.error('Erro ao deletar contato:', error);
            setMessage('Erro ao deletar contato, tente novamente.');
        }
    };

    return (
        <div>
            <button onClick={handleDelete}>Deletar Contato</button>
            {message && <p>{message}</p>}
        </div>
    );
};

export default DeleteContact;
