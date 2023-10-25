import React from "react";
import { Route, Routes } from 'react-router-dom';
import Services from "../Services/Service";
import Header from "../Header/Header";
import Home from "../Home/Home";
import Footer from "../Footer/Footer";
import Periodic from "../Services/Periodic";
import AcService from "../Services/ACService";
import DentPaint from "../Services/DentPaint";
import Signup from "../Garage/Registration/Signup";
import Login from "../Login/Login";
import Profile from "../Garage/Registration/GarageProfile/Profile";
import OrdDetail from "../Garage/Registration/OrderDetail/OrderDetail";
import Logout from "../Garage/Logout/Logout";


const Layout = () => {
  return (
    <>
      <Header />
      
      <Routes>
        <Route path="/" element={<Home/>} />
        <Route path="/Home" element={<Home/>} />
        <Route path="/Periodic" element={<Periodic />} />
        <Route path="/DentPaint" element={<DentPaint/>} />
        <Route path="/AcService" element={<AcService />} />
        <Route path="/Services" element={<Home/>} />
        <Route path="/Registration" element={<Signup/>} />
        <Route path="/Login" element={<Login />} />
        <Route path="/Logout" element={<Logout/>} />
       
      </Routes>
    

      <Routes>
        <Route path="/Profile" element={<Profile />} />
        <Route path="/OrderDetail/:orderid" element={<OrdDetail />} />
      </Routes>

      <Footer />
      
    </>
  );
};

export default Layout;

