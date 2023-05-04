import React from 'react'
import "bootstrap/dist/css/bootstrap.min.css"
import { useState,useEffect } from 'react'
import { useNavigate } from 'react-router-dom';

const Modal2 = ({setModal2}) => {

   const [users, setUser]=useState([]);
 
  
  //   let navigate = useNavigate();

 

    const getthing = (event) => {
        const name = event.target.name;
        const value = event.target.value;
        setUser(values => ({ ...values, [name]: value }))
    }
  
    const addmethod = () => {
     
        let takevalue = JSON.stringify(users);
        
        fetch("https://localhost:7030/api/Users", {
            method: 'Post',
            headers: { 'Content-type': 'application/json' },
            body: takevalue
        }).then(r => { console.log(r.json()) })

        
  

     }  

  return (
    <div className='backshadow'>
     <div className='custom-modal'>

     <div className='delete-icon'
     onClick={()=>setModal2(false)}>X</div>

     <h2>Registration Form</h2>
     <form className='form-group' onSubmit={addmethod}>
     <input class="text" type="text" name="userName" placeholder="Username" required="" value={users.userName || ""} onChange={getthing}/>

        <br></br><br></br>
        <input class="text" type="text" name="password" placeholder="Password" required="" value={users.password || ""} onChange={getthing}/>
        <br></br><br></br>
        <input class="text" type="text" name="email" placeholder="Email" required="" value={users.email || ""} onChange={getthing}/>
        <br></br><br></br>
        <input class="text" type="text" name="fName" placeholder="First Name" required="" value={users.fName || ""} onChange={getthing}/>
        <br></br><br></br>
        <input class="text" type="text" name="lName" placeholder="Last Name" required="" value={users.lName || ""} onChange={getthing}/>
        <br></br><br></br>
        <input class="text" type="tel" name="mobileNumber" placeholder="Mobile Number" required="" value={users.mobileNumber || ""} onChange={getthing}/>
        <br></br><br></br>
        <input class="text" type="text" name="address" placeholder="Address" required="" value={users.address || ""} onChange={getthing}/>
        <br></br><br></br>
       
        <button type="submit" className='btn btn-success btn-md'>
            Register
        </button>       
     </form>
    </div>
    </div>
  );
}

export default Modal2;
