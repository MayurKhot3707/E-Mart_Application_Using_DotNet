import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import Button2 from './Button2';
import { useState } from 'react';
import Modal2 from './Modal2';

const Modal1 = ({ setModal1, setIsLoggedIn }) => {
  const [modal2, setModal2] = useState(false);

  const [user, setUser] = useState({
    userName: '',
    password: ''
  });

  const [errorMessage, setErrorMessage] = useState('');

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setUser(prevState => ({ ...prevState, [name]: value }));
  }

  const handleSubmit = async (event) => {
    event.preventDefault();

    fetch("https://localhost:7030/api/Logins", {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(user)
    })
      .then(response => response.json())
      .then(data => {
        if (data.userName) {
          console.log(data);
          alert("Login done");

          // Store user data in session storage
          sessionStorage.setItem('userData', JSON.stringify(data));
          setIsLoggedIn(true);
          setModal1(false);
        } else {
          setErrorMessage("Invalid data");
        }
      })
      .catch(error => {
        console.log(error);
        setErrorMessage("Wrong Credrntial : UserName and Password incorrect");
      });
  }

  return (
    <div className='backshadow'>
      <div className='custom-modal2'>

        <div className='delete-icon' onClick={() => setModal1(false)}>X</div>

        <h2>Login Form</h2>
        <br /><br />
        {errorMessage && <div className="error-message">{errorMessage}</div>}
        <form className='form-group' onSubmit={handleSubmit}>

          <input className="text" type="text" name="userName" placeholder="Username" required="" value={user.userName} onChange={handleInputChange} />
          <br /><br />

          <input className="text" type="password" name="password" placeholder="Password" required="" value={user.password} onChange={handleInputChange} />
            <br /><br />

            <button type="submit" className='btn btn-success btn-md'>
              LOGIN
            </button>
          </form>
        <br />
        <Button2 setModal2={setModal2} />
        {modal2 === true && (
          <Modal2 setModal2={setModal2} />
        )}

      </div>
    </div>
  );
};

export default Modal1;