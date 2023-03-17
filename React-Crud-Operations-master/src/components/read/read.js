import React, { useEffect, useState } from 'react';
import { Table, Button } from 'semantic-ui-react';
import axios from 'axios';
import { Link } from 'react-router-dom';

export default function Read() {
    const [APIData, setAPIData] = useState([]);
    useEffect(() => {
        axios.get(`http://localhost:5000/api/v2/user/getallusers`)
            .then((getData) => {
                setAPIData(getData.data);
            })
    }, [])

    const setData = (data) => {
        let {userid, firstName, lastName} = data;
        localStorage.setItem('ID', userid);
        localStorage.setItem('First Name', firstName);
        localStorage.setItem('Last Name', lastName);
    }

    const getData = () => {
        axios.get(`http://localhost:5000/api/v2/user/`)
            .then((getData) => {
                setAPIData(getData.data);
            })
    }

    const onDelete = (userid) => {
        axios.delete(`http://localhost:5000/api/v2/user/${userid}`)
        
    }

    return (
        <div>
            <Table compact>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>ID</Table.HeaderCell>
                        <Table.HeaderCell>First Name</Table.HeaderCell>
                        <Table.HeaderCell>Last Name</Table.HeaderCell>
                        <Table.HeaderCell>Email</Table.HeaderCell>
                        <Table.HeaderCell>Update</Table.HeaderCell>
                        <Table.HeaderCell>Delete</Table.HeaderCell>
                    </Table.Row>
                </Table.Header>

                <Table.Body>
                    {APIData.map((data) => {
                        return (
                            <Table.Row>
                                <Table.Cell>{data.userId}</Table.Cell>
                                <Table.Cell>{data.firstName}</Table.Cell>
                                <Table.Cell>{data.lastName}</Table.Cell>
                                <Table.Cell>{data.email}</Table.Cell>
                                <Table.Cell>
                                    <Link to='/update'>
                                        <Button
                                            color="green"
                                            onClick={() => setData(data.userId, data.firstName, data.lastName)}>
                                            Update
                                        </Button>
                                    </Link>
                                </Table.Cell>
                                <Table.Cell>
                                    <Button color="red" onClick={() => onDelete(data.userId)}>Delete</Button>
                                    
                                </Table.Cell>
                            </Table.Row>
                        )
                    })}

                </Table.Body>
            </Table>
        </div>
        
    )
}
