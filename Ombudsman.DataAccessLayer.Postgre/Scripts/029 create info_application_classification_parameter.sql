CREATE TABLE ombudsman.info_application_classification_parameter
(
    id integer,
    parameter_id integer NOT NULL,
    application_classification_id integer NOT NULL,
    CONSTRAINT application_classification FOREIGN KEY (application_classification_id)
        REFERENCES ombudsman.info_application_classification (id) ,
    CONSTRAINT parameter FOREIGN KEY (parameter_id)
        REFERENCES ombudsman.info_parameters (id)
)