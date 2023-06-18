import { ChangeEventHandler, FC, useState } from "react"
import { Button, Form, Modal } from "react-bootstrap"
import { useAppDispatch } from "../../../store/store";
import { tweetsActions } from "../tweetsSlice";
import { TweetType } from "../../../components/Tweet";

export const TweetCreateModal:FC = () => {

    const dispatch = useAppDispatch();

    const [show, setShow] = useState(false)

    const handleClose = () => setShow(false)
    const handleShow = () => setShow(true)



    const [tweet, setTweet] = useState<TweetType>({id: "", createdAt: "", updatedAt: "", userId: "1", userName: "Max",
    uniqueName: "zhmax", content: "", rootTweet: null, tweets: null, likes: 0})


    const handleChange: ChangeEventHandler<HTMLInputElement | HTMLTextAreaElement> = (event) => {
        event.preventDefault()
        setTweet({...tweet, id: Date.now().toString(), content: event.target.value})
    }

    const createTweet = () => {
        dispatch(tweetsActions.addTweet(tweet))
    }

    return (
        <>
        <Button variant="primary" onClick={handleShow}>
            Create Tweet
        </Button>

        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
            <Modal.Title>Create tweet</Modal.Title>
            </Modal.Header>
            <Modal.Body>
            <Form>
                <Form.Group
                className="mb-3"
                >
                <Form.Control value={tweet.content} onChange={handleChange} as="textarea" rows={3} />
                </Form.Group>
            </Form>
            </Modal.Body>
            <Modal.Footer>
            <Button onClick={handleClose}>
                Close
            </Button>
            <Button onClick={()=>{
                createTweet()
                handleClose()
            }} >
                Save Changes
            </Button>
            </Modal.Footer>
        </Modal>
        </>
    );
}