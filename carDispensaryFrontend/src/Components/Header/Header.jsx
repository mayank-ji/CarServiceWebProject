import "../Header/Header.css";
import { useEffect, useState } from "react";
import "../Header/image/earth-americas-solid.svg";
import Dropdown from 'react-bootstrap/Dropdown';
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";

const Header = () => {

    
    const [location, setLocation] = useState("");
    const navigate = useNavigate();
    const handleLocation = (name) => {
        setLocation(name);
        // console.log("Clicked by: " + name);
        debugger;
        localStorage.setItem("city", name);
        navigate("/");


    };

  

; 



    return (


        <header >
            <div className="head">
                {/* ----------------top heder----------------- */}
                <div className="container-fluid header_top">

                    <div className="header__location d-flex align-items-center gap-2" >
                        <div>
                            <img style={{ height: "50px", width: "50px" }} src="https://www.freeiconspng.com/uploads/car-icon-png-25.png" alt="Car Photos Icon" />
                        </div>

                        <div className="header__location-content m-lg-3">
                            <h4>Car</h4>
                            <h6>Dispensery</h6>
                        </div>
                    </div>


                    <div className="header__location d-flex align-items-center gap-2 ">
                        <div>
                            <img style={{ height: "50px" }} src="data:image/jpeg;base64,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" alt="img"></img>
                        </div>
                        <div className="header__location-content m-lg-2">
                            <h4>India</h4>
                            <h6>{location} Madhya Pradesh </h6>
                        </div>
                    </div>



                    <div className="header__location d-flex align-items-center gap-2">
                        <div>
                            <img style={{ height: "50px" }} src="https://cdn.icon-icons.com/icons2/1993/PNG/512/clock_hour_minute_second_time_timer_watch_icon_123193.png" alt="img"></img>
                        </div>
                        <div className="header__location-content m-lg-3">
                            <h4>Monday to Saturday</h4>
                            <h6>10am - 7pm</h6>
                        </div>
                    </div>


                    <div className="header__location d-flex align-items-center gap-2">
                        <Dropdown style={{ color: "white" }} >
                            <Dropdown.Toggle id="dropdown-basic">
                                Location
                            </Dropdown.Toggle>

                            <Dropdown.Menu>
                                <Dropdown.Item onClick={() => handleLocation('Indore ')}>Indore</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleLocation('Bhopal')}>Bhopal</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleLocation('Ujjain ')}>Ujjain</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleLocation('Dewas ')}>Dewas</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleLocation('Ratlam ')}>Ratlam</Dropdown.Item>
                                <Dropdown.Item onClick={() => handleLocation('Shajapur ')}>Shajapur</Dropdown.Item>
                            </Dropdown.Menu>
                        </Dropdown>
                    </div>
                </div>
                {/* --------------------------------------- lower header-------------------------------------  */}

                <div className="header__lower">

                    <div className="header__lower__divfirst gap-5">
                        <div >
                            <Link className="Link" to="/Home">Home</Link>

                        </div>
                        <div>
                            <Link className="Link" to="/About">About</Link>
                        </div>
                        <div>
                            <Link className="Link" to="/Contact">Contact</Link>
                        </div>
                        <div>
                            <Link className="Link" to="/Blog">Blog</Link>
                        </div>
                        <div>
                            <Link className="Link" to="/Services">Services</Link>
                        </div>

                    </div>


                    {/* ----------------------------------------------- right Side---------------------------------------------------------------- */}

                    <div className="header__lower__divsecond gap-5">
                        {/* Login and Register links */}

                        <div>
                            <Link className="Link" to="/Registration">Registration</Link>
                        </div>

                        <div >
                            <Link className="Link" to="/Login">Login</Link>
                        </div>
                      
                        </div> 
                </div>

            </div>
        </header>
    )

}

export default Header;