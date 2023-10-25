import { Link } from "react-router-dom";
import "../Services/Service.css"
import carImage from "../Services/image/download.png";
import carPaint from "../Services/image/paint.webp";
import carAc from "../Services/image/thermocar.png";
import Periodic from "./Periodic";
const Service = () => {



    return (

        <div className="container-fluid">
            <div className="service__root">
            <div id="zero" className="service__zero">
                    <p>
                        <div className="service__zero__content">
                            <h3>Car Services We Provide</h3>
                        </div>
                        Find the best car service packages for your car.
                        Select from a wide range of car repairs & services,
                        from general service, car wash, accidental repair to custom repairs,
                        cashless insurance claims, and much more.</p>
                </div>

                <div id="first" className="container-fluid Service__first">

                    <div className="service1">
                        <Link style={{ textDecoration: 'none', color: 'black' }} to="/Periodic">
                            <div style={{ paddingLeft: '45px', paddingTop: '20px' }}>
                                <img style={{ height: '90px', width: '120px' }} src={carImage} alt="image"></img>


                            </div>
                            <br />

                            <div style={{ textAlign: 'center', paddingTop: '10px', textDecorationLine: '' }}>
                                <h5>Periodic Services</h5>
                            </div>
                        </Link>
                    </div>

                    <div className="service1">
                        <Link style={{ textDecoration: 'none', color: 'black' }} to="/DentPaint">
                            <div style={{ paddingLeft: '45px', paddingTop: '20px' }}>
                                <img style={{ height: '100px', width: '130px' }} src={carPaint} alt="image"></img>


                            </div>
                            <br />

                            <div style={{ textAlign: 'center' }}>
                                <h5>Dent & Paint</h5>
                            </div>
                        </Link>
                    </div>

                    <div className="service1">

                        <Link style={{ textDecoration: 'none', color: 'black' }} to="/AcService">

                            <div style={{ paddingLeft: '45px', paddingTop: '20px' }}>
                                <img style={{ height: '120px', width: '140px' }} src={carAc} alt="image"></img>


                            </div>


                            <div style={{ textAlign: 'center', paddingTop: '5px' }}>
                                <h5>AC Service</h5>
                            </div>
                        </Link>
                    </div>

                    <div className="service1">

                        <div style={{ paddingLeft: '45px', paddingTop: '20px' }}>
                            <img style={{ height: '100px', width: '130px' }} src={carImage} alt="image"></img>


                        </div>
                        <br />

                        <div style={{ textAlign: 'center' }}>
                            <h5>Periodic Services</h5>
                        </div>

                    </div>

                </div>

            </div>
        </div>


    )
}
export default Service;