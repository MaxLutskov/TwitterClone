import { useEffect } from 'react';
import {Button, Col, Container, Row } from 'react-bootstrap';
import { SideBar } from './components/SideBar';
import { TweetList } from './components/TweetList';
import { useAppSelector } from './store/store';
import { useDispatch } from 'react-redux';
import { tweetsActions } from './modules/tweets/tweetsSlice';
import { TweetCreateModal } from './modules/tweets/components/TweetCreateModal';
import { authActions } from './modules/auth/authSlice';


function App() {

  const tweets = useAppSelector(s => s.tweets.tweets)
  const dispatch = useDispatch();

  useEffect(()=>{
    //dispatch(tweetsActions.getTweets)
  }, [])

  const registerHandle = () => {
    dispatch(authActions.registerAsync({email: "admin2@admin.com", userName: "Max", password: "12345"}))
  }

  const loginHandle = () => {
    dispatch(authActions.loginAsync({email: "admin@admin.com", password: "12345"}))
  }

  return (
    <div className="App">
      <Container fluid>
        <Row>
          <Col sm={2}><SideBar/></Col>
          <Col>
          <TweetCreateModal/>
          <Button onClick={registerHandle}>Register</Button>
          <Button onClick={loginHandle}>Login</Button>
          <TweetList tweets={tweets}/>
          </Col>
        </Row>
      </Container>
    </div>
  );
}

export default App;
