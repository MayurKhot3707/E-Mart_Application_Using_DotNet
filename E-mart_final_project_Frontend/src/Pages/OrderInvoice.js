import "bootstrap/dist/css/bootstrap.min.css";
import jsPDF from "jspdf";
import pdfMake from "pdfmake";
import pdfFonts from "pdfmake/build/vfs_fonts";
import htmlToPdfmake from "html-to-pdfmake";
import React, { useState, useEffect } from "react";

const OrderInvoice = () => {
  const [ordersdata, setOrdersdata] = useState([]);

  const [myObject, setMyObject] = useState({});
  useEffect(() => {
    const storedObject = sessionStorage.getItem("userData");
    if (storedObject) {
      setMyObject(JSON.parse(storedObject));
    }
  }, []);

  useEffect(() => {
    fetch("https://localhost:7030/api/Orders")
      .then((res) => res.json())
      .then((result) => {
        setOrdersdata(result);
      });
  }, []);

  useEffect(() => {
    console.log(ordersdata);
  }, [ordersdata]);

  const printDocument = () => {
    const doc = new jsPDF();

    //get html
    const pdfTable = document.getElementById("divToPrint");
    //html to pdf format
    var html = htmlToPdfmake(pdfTable.innerHTML);

    const documentDefinition = { content: html };
    pdfMake.vfs = pdfFonts.pdfMake.vfs;
    pdfMake.createPdf(documentDefinition).open();
  };

  const calculateTotal = (item) => {
    let total = 0;
    ordersdata.forEach((curItem) => {
      total += curItem.price * curItem.qty;
      //total += curItem.price;
    });
    return total;
  };

  return (
    <div className="App container mt-5">
      <button className="btn btn-info" onClick={printDocument}>
        Download Invoice
      </button>

      <div id="divToPrint" className="m-10">
        <div className="row d-flex justify-content-center">
          <div className="col-md-8">
            <div className="card">
              <div className="d-flex flex-row p-2">
                <div className="d-flex flex-column">
                  {" "}
                  <span className="font-weight-bold">
                    Tax Invoice No. INV-001
                  </span>{" "}
                </div>
              </div>
              <hr />

              <div className="table-responsive p-2">
                <table className="table table-borderless">
                  <tbody>
                    <tr className="add">
                      <td>To</td>
                      <td>From</td>
                    </tr>
                    <tr className="content">
                      <td className="font-weight-bold">
                        {" "}
                        {/* {ordersdata[0].userName} <br /> {ordersdata[0].address}{" "} */}
                        {myObject.userName} <br/> {myObject.address}
                      </td>
                      <td className="font-weight-bold">
                        EMART <br /> Group-06 <br /> Juhu,Mumbai
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
              <hr />

              <div className="products p-2">
                <table className="table table-borderless">
                  <tbody>
                    <tr className="add">
                      <td>ProductName</td>
                      <td>Quantity</td>
                      <td>Price</td>
                      <td className="text-center">Total</td>
                    </tr>

                    {ordersdata.map((curItem) => (
                      <tr className="content" key={curItem.orderTID}>
                        <td>{curItem.productName}</td>
                        <td>{curItem.qty}</td>
                        <td>{curItem.price}</td>
                        <td className="text-center">
                          {curItem.price * curItem.qty}
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>

                <hr />
                <div className="products p-2">
                  <table className="table table-borderless">
                    <tbody>
                      <tr className="add">
                        <td></td>
                        <td>Subtotal</td>
                        <td>GST(10%)</td>
                        <td className="text-center">Total</td>
                      </tr>
                      <tr className="content">
                        <td></td>
                        <td> {calculateTotal(ordersdata)}</td>
                        <td>{calculateTotal(ordersdata) * 0.1}</td>
                        <td className="text-center">
                          ${calculateTotal(ordersdata) * 1.1}
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
                <hr />
                <div className="address p-2">
                  <table className="table table-borderless">
                    <tbody>
                      <tr className="add">
                        <td>EMART</td>
                      </tr>
                      <tr className="content">
                        <td>
                          {" "}
                          Account ID : 00220022 <br /> Account Name : Group -06
                          SM VITA <br /> Invoice Number : 6953PO789 <br />{" "}
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default OrderInvoice;

// <div className="card-total">
//         <h3>
//           Cart Total : <span>
//           {calculateTotal(item)}
//           ₹</span>

//         </h3>
//         <button>Place Order</button>
//         <button className="clear-cart">
//           Clear Cart
//         </button>
//       </div>
