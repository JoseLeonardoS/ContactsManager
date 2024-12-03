import UpdateContact from "./UpdateContact";
import DeleteContact from "./DeleteContact";

function ContactBlock({id, name, email, phone}){
    return (
        <div>
            <div>
                <p>Id: {id}</p>
                <p>Nome: {name} </p>
                <p>Email: {email}</p>
                <p>Telefone: {phone}</p>
            </div>
            <div>
                <UpdateContact id={id}/>
                <DeleteContact id={id}/>
            </div>
        </div>
    )
}

export default ContactBlock;
