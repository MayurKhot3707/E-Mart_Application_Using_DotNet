import React, { useRef } from "react";
import AddToCartProductCard from "../SmallComponent/AddToCartProductCard";
import { useState, useEffect } from "react";
import Checkout from "./Checkout";

export default function AddToCart(props) {
  const childCheckboxRef = useRef(null);
  const [item, setItem] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7030/api/AddToCarts")
      .then((res) => res.json())
      .then((result) => {
        setItem(result);
        console.log(item);
      });
  }, []);
  // alert(item);
  const calculateTotal = (item) => {
    let total = 0;
    item.forEach((curItem) => {
        if (childCheckboxRef.current) {
            alert("before"+childCheckboxRef.current);
            if (childCheckboxRef.current.checked) {
              // Do something if checkbox is checked
              console.log("Checkbox is checked");
              total += curItem.cardHolderPrice * curItem.qty;
            } else {
                alert("hi");
              // Do something if checkbox is not checked
              console.log("Checkbox is not checked");
              total += curItem.price * curItem.qty;
            }
          }
    //   if (childCheckboxRef.current && childCheckboxRef.current.checked) {
    //     total += curItem.cardHolderPrice * curItem.qty;
    //   } else {
    //     total += curItem.price * curItem.qty;
    //   }
    total += curItem.price * curItem.qty;
    });
    return total;
  };

  const SendToCheckout = () => {

    // <Checkout object={item}/>
  }

  return (
    <div>
      <h2 align="center">Your Cart</h2>
      <div className="container-fluid">
        <div class="row">
          <div class="col-9">
            <div className="div-partition">
              <div className="heading">
                {/* <h2 align="center">Cart is Empty...</h2> */}
              </div>
              <div className="card">
                {item.map((c) => {
                  return (
                    <AddToCartProductCard
                      name={c.productName}
                      img={c.productImage}
                      desc={c.productShortDesc}
                      price={c.price}
                      discount={c.discount}
                      cardHprice={c.cardHolderPrice}
                      pointredm={c.pointRedm}
                      qty={c.qty}
                      catidid={c.cartID}
                      productid={c.productID}
                    />
                  );
                })}
              </div>
            </div>
          </div>
          <div className="col-3">
            <div className="card w-53">
              <div className="card-body">
                <h5 className="card-title">Cart Total</h5>
                <p className="card-text">
                  <h5>
                  {/* <AddToCartProductCard ref={childCheckboxRef} /> */}
                    <span>₹{calculateTotal(item)}</span>
                  </h5>
                </p>
                <a href="/Checkout" className="btn btn-info" onClick={SendToCheckout}>
                  Place Order
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
