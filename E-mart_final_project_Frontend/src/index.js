import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { SecondPage } from "./SmallComponent/Secondpage";
import DescPage from "./SmallComponent/DescPage";
import Footer from "./Component/Footer"
import Navbar from "./Component/Navbar"
import AddToCart from "./Pages/AddToCart";
import Checkout from "./Pages/Checkout";
import Payment from "./Pages/Payment";
import Order from "./Pages/Order";
import OrderInvoice from "./Pages/OrderInvoice";
import Searchnew from "./Component/Searchnew";
// import Cart123 from "./Component/Cart123"

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <BrowserRouter>
    <Navbar/>
      <Routes>
        <Route path="/" element={<App />} />

        {/* <Route path='Getlist' element={<Getlist/>}/> */}

        <Route path="/AddToCart" element={<AddToCart />} />
        <Route path="/Secondpage/:catMasterID" element={<SecondPage />} />
        <Route path="/DescPage/:productID" element={<DescPage />} />
        <Route path="/Checkout" element={<Checkout />} />
        <Route path="/Payment" element={<Payment />} />
        <Route path="/Order" element={<Order />} />
        <Route path="/OrderInvoice" element={<OrderInvoice />} />
        <Route path="/Searchnew/:productname" element={<Searchnew />} />

      </Routes>
      <Footer/>
    </BrowserRouter>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
