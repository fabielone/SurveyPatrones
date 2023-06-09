import React, { useState, useEffect } from 'react';


  
  function AddSurveyForm() {
    const [title, setTitle] = useState('');
  
    const handleTitleChange = event => {
      setTitle(event.target.value);
    };
  
    const handleSubmit = event => {
      event.preventDefault();
  
      fetch('http://localhost:5038/surveys', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ title }),
      })
        .then(response => response.json())
        .then(data => {
          // Handle the response or update the survey list
          console.log(data);
        });
  
      setTitle('');
    };
  
    return (
      <form onSubmit={handleSubmit}>
        <h2>Add Survey</h2>
        <input
          type="text"
          placeholder="Title"
          value={title}
          onChange={handleTitleChange}
        />
        <button type="submit">Add</button>
      </form>
    );
  }
  

function EditSurveyForm({ survey, onUpdate }) {
  const [title, setTitle] = useState(survey.title);

  const handleTitleChange = event => {
    setTitle(event.target.value);
  };

  const handleSubmit = event => {
    event.preventDefault();

    fetch(`http://localhost:5038/surveys/${survey.id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ id: survey.id, title }),
    })
      .then(response => response.json())
      .then(data => {
        // Handle the response or update the survey list
        onUpdate(data);
      });
  };

  return (
    <form onSubmit={handleSubmit}>
      <p>Edit Survey</p>
      <input
        type="text"
        placeholder="Title"
        value={title}
        onChange={handleTitleChange}
      />
      <button type="submit">Update</button>
    </form>
  );
}

function DeleteSurveyButton({ survey, onDelete }) {
  const handleDelete = () => {
    fetch(`http://localhost:5038/surveys/${survey.id}`, {
      method: 'DELETE',
    })
      .then(() => {
        // Handle the response or update the survey list
        onDelete(survey.id);
      });
  };

  return (
    <button onClick={handleDelete}>Delete</button>
  );
}

function SurveyList() {
  const [surveys, setSurveys] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5038/surveys')
      .then(response => response.json())
      .then(data => setSurveys(data));
  }, []);

  const handleSurveyUpdate = updatedSurvey => {
    const updatedSurveys = surveys.map(survey => {
      if (survey.id === updatedSurvey.id) {
        return updatedSurvey;
      }
      return survey;
    });
    setSurveys(updatedSurveys);
  };

  const handleSurveyDelete = deletedSurveyId => {
    const updatedSurveys = surveys.filter(survey => survey.id !== deletedSurveyId);
    setSurveys(updatedSurveys);
  };

  return (
    <div>
      <h1>Surveys</h1>
      
        {surveys.map(survey => (
          <div key={survey.id}>
            <div style={{"display":"flex","flexDirection":"row"}} >
            <p>Title: {survey.title}</p>
            <EditSurveyForm survey={survey} onUpdate={handleSurveyUpdate} />
            <DeleteSurveyButton survey={survey} onDelete={handleSurveyDelete} />
            </div>
            <hr/>
          </div>
        ))}
      
      <AddSurveyForm />
    </div>
  );
}

export default SurveyList;
