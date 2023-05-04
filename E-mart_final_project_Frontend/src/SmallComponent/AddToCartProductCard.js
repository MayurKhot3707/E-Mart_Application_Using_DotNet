import React from 'react';
import "./AddToCartProductCard.css";
import DeleteIcon from "@mui/icons-material/Delete";
import { NavLink } from "react-router-dom";
import { useState, useEffect } from "react";
import AddToCart from "../Pages/AddToCart";

export default function AddToCartProductCard(props) {
  const handledelete = (id) => {
    fetch("https://localhost:7030/api/AddToCarts/" + id, {
      method: "Delete",
    })
      .then((res) => res.json())
      .then((result) => {
        console.log(result);
      });
    window.location.reload();
  };

  let a = props.qty + 1;
  const [clickCount, setClickCount] = useState(a);

  let b = props.qty - 1;
  const [clickCount1, setClickCount1] = useState(b);

  function handleClick1(catid) {
    setClickCount(clickCount + 1);

    if (clickCount >= 1) {
      addQtyToAddToCart(catid);
    } else {
      SecondMethodUpdate();
    }
  }

  function handleClick2(catid) {
    setClickCount(clickCount1 - 1);

    if (clickCount1 >= 1) {
      addQtyToAddToCart1(catid);
    } else {
      SecondMethodUpdate();
    }
  }

  const SecondMethodUpdate = () => {
    alert("qty cannot be less than 1");
  };

  const addQtyToAddToCart1 = (id) => {
    const object = {
      productID: props.productid,
      price: props.price,
      discount: props.discount,
      cardHolderPrice: props.cardHprice,
      pointRedm: props.pointredm,
      qty: clickCount1,
      productImage: props.img,
      productShortDesc: props.desc,
      productName: props.name,
      cartID: props.catidid,
    };

    let demo = JSON.stringify(object);
    fetch("https://localhost:7030/api/AddToCarts/" + id, {
      method: "PUT",
      headers: { "Content-type": "application/json" },
      body: demo,
    }).then((r) => {
      console.log(r.json());
    });

    window.location.reload();
  };

  const addQtyToAddToCart = (id) => {
    const object = {
      productID: props.productid,
      price: props.price,
      discount: props.discount,
      cardHolderPrice: props.cardHprice,
      pointRedm: props.pointredm,
      qty: clickCount,
      productImage: props.img,
      productShortDesc: props.desc,
      productName: props.name,
      cartID: props.catidid,
    };

    let demo = JSON.stringify(object);
    fetch("https://localhost:7030/api/AddToCarts/" + id, {
      method: "PUT",
      headers: { "Content-type": "application/json" },
      body: demo,
    }).then((r) => {
      console.log(r.json());
    });

    window.location.reload();
  };

  const [isChecked, setIsChecked] = useState(false);
  const method = (event) => {
    // const isChecked = event.target.checked;
    // alert(isChecked); // Outputs true if the checkbox is checked, false if it's unchecked
    setIsChecked(!isChecked);
    alert(isChecked);
  };

  return (
    <div>
      <div className="card-container">
        <div className="card-column">
          &nbsp;
          <img src={props.img} alt="Card Image" width="200" height="200" />
        </div>
        <div className="card-column">
          <h5>{props.name}</h5>
          <p>{props.desc}</p>
          <label>
            <h6>Card Holder Price : {props.cardHprice}</h6>
          </label>
          <br />
          <label>
            <h6>Max Points Redeem : {props.pointredm}</h6>
          </label>{" "}
          &nbsp;
          <br />
          <label>
            Redeem Points  <input type="checkbox" checked={isChecked} onChange={method} />
          </label>
          <br />
          <br />
          <div class="btn-group" role="group" aria-label="Basic example">
            <button
              type="button"
              class="btn btn-light"
              onClick={() => handleClick2(props.catidid)}
            >
              <b>-</b>
            </button>
            <button type="button" class="btn btn-light">
              {props.qty}
            </button>
            <button
              type="button"
              class="btn btn-light"
              onClick={() => handleClick1(props.catidid)}
            >
              <b>+</b>
            </button>
          </div>
        </div>
        <div className="card-column">
          <h5>₹{props.price}</h5>
          <NavLink
            className="nav-link"
            to="/AddToCart"
            onClick={() => handledelete(props.catidid)}
          >
            <DeleteIcon />
          </NavLink>
        </div>
      </div>
      <hr />
      <hr />
    </div>
  );
}
