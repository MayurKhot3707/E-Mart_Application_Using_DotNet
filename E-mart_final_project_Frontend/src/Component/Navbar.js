import React from "react";
import { NavLink } from "react-router-dom";
import ShoppingCartSharpIcon from "@mui/icons-material/ShoppingCartSharp";
import { useNavigate } from "react-router-dom";
import Button from "../SmallComponent/Button";
import { useState } from "react";
import Button2 from "../SmallComponent/Button2";
import Modal1 from "../SmallComponent/Modal1";
import Modal2 from "../SmallComponent/Modal2";

import Modal from "react-modal";

export default function Navbar() {
  const [modal1, setModal1] = useState(false);
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const [searchTerm, setSearchTerm] = useState('');

  const onchangemethod =(event) =>{
    const value = event.target.value;
    setSearchTerm(value);
  }

  const handleLogout = () => {
    // Remove user data from session storage
    sessionStorage.removeItem('userData');
    setIsLoggedIn(false);
  }

  // Check if user is already logged in
  React.useEffect(() => {
    const userData = sessionStorage.getItem('userData');
    if (userData) {
      setIsLoggedIn(true);
    }
  }, []);

  let navigate = useNavigate();
  const gotosearchpage = () => {
    //alert("hi")
    navigate("/ProductSearch");
  };
  return (
    <div>
      <div className="container-fluid nav_bg">
        <div className="row">
          <div className="col-12 mx-auto">
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
              <div className="container-fluid">
                <NavLink className="navbar-brand" to="/">
                  E-Mart
                </NavLink>
                <button
                  className="navbar-toggler"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#navbarSupportedContent"
                  aria-controls="navbarSupportedContent"
                  aria-expanded="false"
                  aria-label="Toggle navigation"
                >
                  <span className="navbar-toggler-icon"></span>
                </button>
                <div
                  className="collapse navbar-collapse"
                  id="navbarSupportedContent"
                >
                  <ul className="navbar-nav mr-auto mb-2 mb-lg-0">
                    {/* <li className="nav-item">
                      <NavLink
                        className="nav-link active"
                        aria-current="page"
                        to="/Home">
                        Home
                      </NavLink>
                    </li>
                    <li className="nav-item me-4  ">
                      <NavLink className="nav-link" to="/">
                        Hello User
                      </NavLink>
                    </li> */}
                    <form className="d-flex">
                      <input
                        className="form-control me-2 "
                        type="text"
                        size="95"
                        placeholder="Search Here"
                        aria-label="Search"
                        onChange={onchangemethod}
                      />
                       <a href={"/Searchnew/"+searchTerm}>search</a>
                       {/* <button
                        className="btn btn-outline-success me-4"
                        type="submit"
                      >
                        Search
                      </button> */}
                      
                    </form>
                    <li className="nav-item ">
                      <NavLink className="nav-link" to="/Order">
                        Order
                      </NavLink>
                    </li>
                    <li className="nav-item right">
                      {/* <NavLink
                        activeClassName="menu_active"
                        className="nav-link"
                        onClick={openModal}>
                        Login
                      </NavLink> */}
                      {/* to="/Login" */}
                      <div className="Login">
                        <br />
                        {isLoggedIn ? (
                          <button
                            className="btn btn-primary btn-md mx-2"
                            onClick={handleLogout}
                          >
                            Logout
                          </button>
                        ) : (
                          <Button setModal1={setModal1} />
                        )}
                        {modal1 === true && (
                          <Modal1
                            setModal1={setModal1}
                            setIsLoggedIn={setIsLoggedIn}
                          />
                        )}
                      </div>
                    </li>
                    <li className="nav-item ">
                      <NavLink className="nav-link" to="/AddToCart">
                        <ShoppingCartSharpIcon className="cart-icon" />
                        {/* <sup>
                          <b>0</b>
                        </sup> */}
                      </NavLink>
                    </li>
                  </ul>
                </div>
              </div>
            </nav>
          </div>
        </div>
      </div>
      {/* <button onClick={openModal}>Open Modal</button> */}
    </div>
  );
}
