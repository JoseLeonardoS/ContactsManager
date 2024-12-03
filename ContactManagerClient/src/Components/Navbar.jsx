import { Link } from "react-router-dom";

function Navbar(){
    return (
        <nav>
            <Link to="/">Início</Link>
            <Link to="/api/Contact/listar-contatos">Contatos</Link>
        </nav>
    )
}

export default Navbar;