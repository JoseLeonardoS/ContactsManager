import axios from "axios";

const api = axios.create({
    baseURL: 'https://localhost:7187/api/Contact',
    timeout: 3000,
    headers: {
        'Content-Type': 'application/json',
    }
});

export default api;
