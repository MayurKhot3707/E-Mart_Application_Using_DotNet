import React from "react";
import { useState, useEffect } from "react";
import CheckoutCard from "../SmallComponent/CheckoutCard";

export default function Checkout(props) {
  const [myObject, setMyObject] = useState({});


  const InsertToOrderMethod = () => {
        {
          item.map((val) => {
              const InsertToOrder = {
                productID: val.productID,
                price: val.price,
                discount:val.discount,
                cardHolderPrice: val.cardHolderPrice,
                pointRedm : val.pointRedm,
                orderDate : new Date(),
                grandTotal : total,
                productName : val.productName,
                qty:val.qty,

                
             };
              console.log(InsertToOrder);
              let takevalue = JSON.stringify(InsertToOrder);

              fetch("https://localhost:7030/api/Orders", {
                method: "Post",
                headers: { "Content-type": "application/json" },
                body: takevalue,
              }).then((r) => {
                console.log(r.json());
              });
              
          });
       
    }
  };


  useEffect(() => {
    const storedObject = sessionStorage.getItem("userData");
    if (storedObject) {
      setMyObject(JSON.parse(storedObject));
    }
  }, []);
// alert(props.object);
  const handleAddressSelection = () => {};

  const [item, setItem] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7030/api/AddToCarts")
      .then((res) => res.json())
      .then((result) => {
        setItem(result);
        console.log(item);
      });
  }, []);

  const calculateTotal = (item) => {
    let total = 0;
    item.forEach((curItem) => {
    total += curItem.price * curItem.qty;
    });
    return total;
  };

  let total = calculateTotal(item);

  return (
    <div className="container">
        <br/>
      <div class="row">
        <div class="col-9">
          <div className="card border-dark mb-3" style={{ maxWidth: "55rem" }}>
            <div className="card-header">
              <h3 className="h3">Checkout</h3>
            </div>
            <div className="card-body text-dark">
              <div
                className="card border-dark mb-3"
                style={{ maxWidth: "50rem" }}
              >
                <div className="card-header">Delivery Address</div>
                <div className="card-body text-dark">
                  <div>
                    <input
                      type="radio"
                      id="address1"
                      name="address"
                      value="Address 1"
                      onChange={handleAddressSelection}
                    />
                    &nbsp;
                    <label htmlFor="address1">
                      <span>
                        <b>
                          {myObject.fName}&nbsp;{myObject.lName}
                        </b>
                      </span>
                      &nbsp;
                      <br />
                      <span>
                        <b>Address: </b>
                      </span>{" "}
                      {myObject.address}
                    </label>
                  </div>
                </div>
              </div>
              <div
                className="card border-dark mb-3"
                style={{ maxWidth: "50rem" }}
              >
                <div className="card-header">Payment Method</div>
                <div className="card-body text-dark">
                  <div>
                    <input
                      type="radio"
                      id="payment"
                      name="payment"
                      value="paymentmode"
                    />{" "}
                    &nbsp;
                    <label>
                      <span>
                        <b>Pay with Debit/Credit/ATM Cards</b>
                      </span>
                      <br />
                      <span>
                        You can save your cards as per new RBI guidelines.
                      </span>
                      &nbsp;
                      <br />
                      <img src="/images/checkout.jpg" alt="Payment Methods" />
                    </label>
                  </div>
                </div>
              </div>
              <div
                className="card border-dark mb-3"
                style={{ maxWidth: "50rem" }}
              >
                <div className="card-header">Products You Buy</div>
                <div className="card-body text-dark">
                {item.map((c) => {
                  return (
                    <CheckoutCard
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
          </div>
        </div>
        <div class="col-3">
          <div className="card border-dark mb-3" style={{ maxWidth: "30rem" }}>
            <div className="card-header">
              <b>Order Summary</b>
            </div>
            <div className="card-body text-dark">
              <label>Items :  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;₹{calculateTotal(item)}</label>
              <br />
              <label>Delivery:&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 0 </label>
              <hr />
              <h5>Order Total :&nbsp; &nbsp; &nbsp; ₹{total} </h5>
              <hr />
              <div className="d-grid gap-2">
                <a href="/Payment" className="btn btn-warning" onClick={InsertToOrderMethod}>
                  Use This Payment Method  
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
