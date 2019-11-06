import React, { Component } from "react";
import axios from "axios";
import NmiDetails from "./NmiDetails";

class Checksum extends Component {
  state = {
    nmiValue: "",
    checksum: null,
    isNmiValid: false,
    isChecksumCalc: false,
    message: ""
  };

  handleChange = e => {
    let value = e.currentTarget.value;
    this.setState({
      nmiValue: value.toUpperCase(),
      checksum: null,
      isNmiValid: null,
      isChecksumCalc: false,
      message: ""
    });
  };

  handleClick = async () => {
    let { nmiValue, checksum, isNmiValid, isChecksumCalc, message } = {
      ...this.state
    };
    const { data: response } = await axios.get(
      "/Home/CalcChecksum?nmiValue=" + nmiValue
    );

    checksum = response.Checksum;
    isNmiValid = response.IsNmiValid;
    isChecksumCalc = response.IsChecksumCalculated;
    message = response.Message;
    this.setState({
      checksum,
      isNmiValid,
      isChecksumCalc,
      message
    });
  };

  render() {
    return (
      <React.Fragment>
        <div className="row">
          <div className="col-sm">
            <input
              className="form-control mr-sm-2"
              type="text"
              placeholder="Enter NMI"
              value={this.state.nmiValue}
              onChange={this.handleChange}
            />
            <button
              className="btn btn-primary"
              type="button"
              onClick={this.handleClick}
            >
              Calculate Checksum
            </button>
          </div>
          <div className="col-lg">
            <NmiDetails
              nmiValue={this.state.nmiValue}
              checksum={this.state.checksum}
              isNmiValid={this.state.isNmiValid}
              isChecksumCalc={this.state.isChecksumCalc}
              message={this.state.message}
            ></NmiDetails>
          </div>
        </div>
      </React.Fragment>
    );
  }
}

export default Checksum;
