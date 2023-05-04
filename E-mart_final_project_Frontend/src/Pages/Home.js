import React from "react";
import { useState, useEffect } from "react";
import Card from "../SmallComponent/Card";
import { useNavigate, useParams } from "react-router-dom";
import { Outlet, Link } from "react-router-dom";
import Carousel from "../Component/Carousel1";
import Carousel1 from "../Component/Carousel1";
import ProductCard from "../SmallComponent/ProductCard";

export default function Home() {
  const [products, setProduct] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');

  const onchangemethod =(event) =>{
    const value = event.target.value;
    setSearchTerm(value);
  }

  useEffect(() => {
    fetch("https://localhost:7030/api/CatMasters")
      .then((res) => res.json())
      .then((result) => {
        setProduct(result);
      });
  }, []);

  const [products1, setProduct1] = useState([]);
  const [products2, setProduct2] = useState([]);
  const [products3, setProduct3] = useState([]);
  const [products4, setProduct4] = useState([]);

  // {products.map((c)=>{
  //   c.
  //   useEffect(() => {
  //     fetch("https://localhost:7030/api/CatMasters/" + id)
  //       .then((res) => res.json())
  //       .then((result) => {
  //         setProduct1(result);
  //         console.log(result);
  //       });
  //   }, []);
  
  // })}
  
  useEffect(() => {
        fetch("https://localhost:7030/api/CatMasters/CatMasters1")
          .then((res) => res.json())
          .then((result) => {
            setProduct1(result);
            console.log(result);
          });
      }, []);
  //     useEffect(() => {
  //       fetch("https://localhost:7030/api/CatMasters/3003")
  //         .then((res) => res.json())
  //         .then((result) => {
  //           setProduct3(result);
  //           console.log(result);
  //         });
  //     }, []);
  //     useEffect(() => {
  //       fetch("https://localhost:7030/api/CatMasters/6")
  //         .then((res) => res.json())
  //         .then((result) => {
  //           setProduct2(result);
  //           console.log(result);
  //         });
  //     }, []);

  //     useEffect(() => {
  //       fetch("https://localhost:7030/api/CatMasters/3012")
  //         .then((res) => res.json())
  //         .then((result) => {
  //           setProduct4(result);
  //           console.log(result);
  //         });
  //     }, []);
  
  return (
    <div>
      <br/>
      <Carousel1/>
      <br/>
      
      <div className="container-fluid mb-5">
        <div className="row">
          <div className="col-12 mx-auto">
            <h3 className="h3">deal of the day</h3>
            <div className="row gt-4">
            {products1.map((val, ind) => {
                return (
                  <ProductCard
                  key={ind}
                  imgsrc={val.c.catImagPath}
                  catname={val.c.catName}
                  id={val.c.catMasterID}
                  price={val.p.price}
                  shortdesc={val.p.productShortDescription}
                  productid={val.c.productID}
                  />
                );
              })}
            </div>
          </div>
        </div>
      </div>
      <hr/>
      <div className="container-fluid mb-5">
        <div className="row">
          <div className="col-12 mx-auto">
            <h3 className="h3">categories</h3>
            <div className="row gt-4">
              {products.map((val, ind) => {
                return (
                  <Card
                    imgsrc={val.catImagPath}
                    catname={val.catName}
                    id={val.catMasterID}
                    productid={val.productID}
                    price={val.price}
                    flag={val.flag}
                  />
                );
              })}
            </div>
          </div>
        </div>
        
      </div>


      <div className="container-fluid mb-5">
        <div className="row">
          <div className="col-12 mx-auto">
            <h3 className="h3">top picks</h3>
            <div className="row gt-4">
            {products1.map((val, ind) => {
                return (
                  <ProductCard
                  key={ind}
                  imgsrc={val.c.catImagPath}
                  catname={val.c.catName}
                  id={val.c.catMasterID}
                  price={val.p.price}
                  shortdesc={val.p.productShortDescription}
                  productid={val.c.productID}
                  />
                );
              })}
              {/* {products1.map((val, ind) => {
                return (
                  <ProductCard
                  key={ind}
                  imgsrc={val.c.catImagPath}
                  catname={val.c.catName}
                  id={val.c.catMasterID}
                  price={val.p.price}
                  shortdesc={val.p.productShortDescription}
                  productid={val.c.productID}
                  />
                );
              })}
              {products2.map((val, ind) => {
                return (
                  <ProductCard
                  key={ind}
                  imgsrc={val.c.catImagPath}
                  catname={val.c.catName}
                  id={val.c.catMasterID}
                  price={val.p.price}
                  shortdesc={val.p.productShortDescription}
                  productid={val.c.productID}
                  />
                );
              })}
              {products3.map((val, ind) => {
                return (
                  <ProductCard
                  key={ind}
                  imgsrc={val.c.catImagPath}
                  catname={val.c.catName}
                  id={val.c.catMasterID}
                  price={val.p.price}
                  shortdesc={val.p.productShortDescription}
                  productid={val.c.productID}
                  />
                );
              })} */}
            </div>
          </div>
        </div>
      </div>

    </div>
  );
}
