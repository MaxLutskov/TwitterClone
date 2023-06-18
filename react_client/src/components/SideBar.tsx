import { FC } from "react";
import { Nav } from "react-bootstrap";

export const SideBar: FC = () => {
    return(
      <Nav defaultActiveKey="/home" className="flex-column  align-content-center">
        <Nav.Item>
          <Nav.Link href="/link1">Home</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link href="/link2">Profile</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link href="/link3">LogIn</Nav.Link>
        </Nav.Item>
    </Nav>
    )
}