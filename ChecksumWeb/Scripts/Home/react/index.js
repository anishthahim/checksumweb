import React from "react";
import { render } from "react-dom";
import Checksum from "./Components/Checksum";

const App = () => (
  <>
    <Checksum></Checksum>
  </>
);

render(<App />, document.getElementById("app"));
